using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource.Summary;
public class CharacterSummary // 角色
{
    public int ID;

    public string Name;

    public string Relation;

    public string Cover;

    public List<ActorSummary> Actors; // 由谁配音/饰演
}