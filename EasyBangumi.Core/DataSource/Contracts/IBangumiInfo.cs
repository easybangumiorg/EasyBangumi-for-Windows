using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.Summary;

namespace EasyBangumi.Core.DataSource.Contracts;
public interface IBangumiInfo
{
    // Task 异步
    // Result 返回结果，有可能返回别的


    // 番剧周表
    Task<List<List<BangumiCoverSummary>>> Calendar();

    // 根据ID获取番剧信息
    Task<BangumiSummary> GetBangumiByID(int id);

    // 搜索番剧
    Task<List<BangumiCoverSummary>> Search(string keyword, int start = 0);
}
