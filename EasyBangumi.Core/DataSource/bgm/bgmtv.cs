using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using EasyBangumi.Core.DataSource.bgm.dto;
using EasyBangumi.Core.DataSource.Contracts;
using EasyBangumi.Core.DataSource.Summary;
using EasyBangumi.Core.Exceptions;
using EasyBangumi.Core.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace EasyBangumi.Core.DataSource.bgm;
public class Bgmtv : IDataSource, IBangumiInfo
{
    public string Key => "bgmtv";

    public string Label => "番组计划RC3";

    public string Version => "1.0.2";

    public int VersionCode => 3;

    public string Description => "Bangumi 是由 Sai 于桂林发起的 ACG 分享与交流项目，致力于让阿宅们在欣赏ACG作品之余拥有一个轻松便捷独特的交流与沟通环境。";

    public string OfficialWebsite => "https://bgm.tv/";

    private readonly RestClient client = new("https://api.bgm.tv");

    public async Task<List<List<BangumiCoverSummary>>> Calendar()
    {
        var summary = new List<List<BangumiCoverSummary>>();

        var request = new RestRequest("/calendar");
        var content = await client.GetAsync(request);

        List<CalendarRoot> calendarData = await Json.ToObjectAsync<List<CalendarRoot>>(content.Content);

        calendarData.ForEach(it =>
        {
            var list = new List<BangumiCoverSummary>();

            foreach (var item in it.items)
            {

                var bgmcs = new BangumiCoverSummary()
                {
                    ID = item.id,
                    Name = string.IsNullOrEmpty(item.name_cn) ? item.name : item.name_cn,
                    Cover = item.images.common,
                    CoverGrid = item.images.grid,
                };

                list.Add(bgmcs);
            }

            summary.Add(list);
        });

        if (summary.Count != 7)
        {
            throw new CalendarUncompleteException(ExceptionType.NotExpect);
        }

        return summary;
    }

    public async Task<BangumiSummary> GetBangumiByID(int id)
    {
        var request = new RestRequest($"/v0/subjects/{id}");
        var content = await client.GetAsync(request);

        if (content.Content.IndexOf("resource can't be found in the database or has been removed") != -1)
        {
            throw new IndexBangumiUncompleteException(ExceptionType.NothingFind);
        }

        SubjectRoot bangumiData = await Json.ToObjectAsync<SubjectRoot>(content.Content);

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
            }
            catch (ArgumentException)
            {
                continue;
            }
        }

        return new BangumiSummary()
        {
            ID = id,
            Name = string.IsNullOrEmpty(bangumiData.name_cn) ? bangumiData.name : bangumiData.name_cn,
            Cover = bangumiData.images.common,
            CoverGrid = bangumiData.images.grid,
            Date = bangumiData.date,
            Summary = bangumiData.summary,
            Score = bangumiData.rating.score,
            TotalEpisodes = bangumiData.total_episodes,
            IsNSFW = bangumiData.nsfw,
            Tags = tags,
            Info = info,
        };
    }

    private readonly Dictionary<string, int> SearchCounts = new();

    public async Task<List<BangumiCoverSummary>> Search(string keyword, int start = 0)
    {
        if (SearchCounts.ContainsKey(keyword) && SearchCounts[keyword] < start || start < 0)
        {
            throw new SearchUncompleteException(ExceptionType.OutOfRange);
        }

        var list = new List<BangumiCoverSummary>();
        var request = new RestRequest($"/search/subject/{keyword}");
        request.AddQueryParameter("type", 2);
        if (start > 0)
        {
            request.AddQueryParameter("start", start);
        }
        var content = await client.GetAsync(request);

        if (content.Content.IndexOf("\"code\":404,\"error\":\"Not Found\"") != -1)
        {
            throw new SearchUncompleteException(ExceptionType.NothingFind);
        }

        SearchSubjectRoot bangumiData = await Json.ToObjectAsync<SearchSubjectRoot>(content.Content);

        SearchCounts[keyword] = bangumiData.results;
        bangumiData.list.ForEach(it =>
        {

            var bgmcs = new BangumiCoverSummary()
            {
                ID = it.id,
                Name = string.IsNullOrEmpty(it.name_cn) ? it.name : it.name_cn,
                Cover = it.images.common,
                CoverGrid = it.images.grid,
            };

            list.Add(bgmcs);
        });

        return list;
    }
}
