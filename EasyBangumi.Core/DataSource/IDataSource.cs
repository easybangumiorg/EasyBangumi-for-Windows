using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource;
public interface IDataSource
{
    // 番剧周表
    Task<List<List<BangumiCoverSummary>>> Calendar();

    // 根据ID获取番剧信息
    Task<BangumiSummary> GetBangumiByID(int id);

    // 搜索番剧
    Task<List<BangumiCoverSummary>> Search(string keyword);
}


public interface IDataSourceExtended: IDataSource
{
    // 获取角色信息
    Task<List<CharacterSummary>> GetCharacterSummariesByID(int id);

    // 获取制作方信息
    Task<List<ProducerSummary>> GetProducerSummariesByID(int id);

    // 获取配音/演员信息
    Task<List<ActorSummary>> GetActorSummariesByID(int id);

    // 获取子类条目
    Task<List<SubjectSummary>> GetSubjectSummariesByID(int id);
}