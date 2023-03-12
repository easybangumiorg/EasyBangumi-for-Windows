using EasyBangumi.Core.DataSource.bgm.dto;
using EasyBangumi.Core.Helpers;
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
                string name;

                if (string.IsNullOrEmpty(item.name_cn)) {
                    name = item.name;
                }
                else
                {
                    name = item.name_cn;
                }

                var bgmcs = new BangumiCoverSummary() {
                    ID = item.id,
                    Name = name,
                    Cover = item.images.common,
                    CoverGrid = item.images.grid,
                };

                list.Add(bgmcs);
            }

            summary.Add(list);
        });

        return summary;
    }
}
