using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource;
internal interface IDataSource
{
    // 每日放送
    Task<List<List<BangumiCoverSummary>>> Calendar();


    // 根据ID获取番剧信息
    Task<BangumiSummary> GetBangumiByID(int id);
}
