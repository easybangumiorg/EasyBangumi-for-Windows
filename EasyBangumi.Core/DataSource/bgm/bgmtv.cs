using System.Text.Json.Nodes;
using System.Xml.Linq;
using EasyBangumi.Core.DataSource.bgm.dto;
using EasyBangumi.Core.Helpers;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace EasyBangumi.Core.DataSource.bgm;
public class Bgmtv : IDataSource
{
    private readonly RestClient client = new RestClient("https://api.bgm.tv");

    public async Task<List<List<BangumiCoverSummary>>> Calendar()
    {
        var summary = new List<List<BangumiCoverSummary>>();

        var request = new RestRequest("/calendar");
        var content = await client.GetAsync(request);

        var calendarData = await Json.ToObjectAsync<List<CalendarRoot>>(content.Content);

        calendarData.ForEach(it => {
            var list = new List<BangumiCoverSummary>();

            foreach (var item in it.items) {

                var bgmcs = new BangumiCoverSummary() {
                    ID = item.id,
                    Name = string.IsNullOrEmpty(item.name_cn) ? item.name : item.name_cn,
                    Cover = item.images.common,
                    CoverGrid = item.images.grid,
                };

                list.Add(bgmcs);
            }

            summary.Add(list);
        });

        return summary;
    }

    public async Task<BangumiSummary> GetBangumiByID(int id)
    {
        var request = new RestRequest($"/v0/subjects/{id}");
        var content = await client.GetAsync(request);

        var bangumiData = await Json.ToObjectAsync<SubjectRoot>(content.Content);

        var tags = new Dictionary<string, int>();
        var info = new Dictionary<string, string>();

        bangumiData.tags.ForEach(tag =>
        {
            tags[tag.name] = tag.count;
        });

        foreach (JObject item in bangumiData.infobox)
        {
            try
            {
                var key = item["key"];
                var value = item["value"];
                info[(string)key] = (string)value;
            } catch(ArgumentException)
            {
                continue;
            }
        }

        string name;
        if (string.IsNullOrEmpty(bangumiData.name_cn))
        {
            name = bangumiData.name;
        }
        else
        {
            name = bangumiData.name_cn;
        }

        return new BangumiSummary() { 
            ID=id,
            Name = name,
            Cover=bangumiData.images.common,
            CoverGrid=bangumiData.images.grid,
            Date=bangumiData.date,
            Summary=bangumiData.summary,
            Score=bangumiData.rating.score,
            TotalEpisodes=bangumiData.total_episodes,
            IsNSFW=bangumiData.nsfw,
            Tags=tags,
            Info=info,
        };
    }

    public async Task<List<BangumiCoverSummary>> Search(string keyword)
    {
        var list = new List<BangumiCoverSummary>();
        var request = new RestRequest($"/search/subject/{keyword}");
        request.AddQueryParameter("type", 2);
        var content = await client.GetAsync(request);

        var bangumiData = await Json.ToObjectAsync<SearchSubjectRoot>(content.Content);

        bangumiData.list.ForEach(it =>
        {

            var bgmcs = new BangumiCoverSummary()
            {
                ID = it.id,
                Name = string.IsNullOrEmpty(it.name_cn)?it.name:it.name_cn,
                Cover = it.images.common,
                CoverGrid = it.images.grid,
            };

            list.Add(bgmcs);
        });

        return list;
    }
}
