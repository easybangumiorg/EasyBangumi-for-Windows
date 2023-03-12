using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Contracts.Sources;
internal interface IComponent
{
    ISource source
    {
        get;
    }
}
