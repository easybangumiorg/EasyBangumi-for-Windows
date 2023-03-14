using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.Summary;

namespace EasyBangumi.Core.DataSource.Contracts;
public interface IBangumiInfoExtended
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
