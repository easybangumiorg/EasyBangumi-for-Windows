using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Contracts.Sources;
internal interface ISource
{
    string Key
    {
        get;
    }

    string Label
    {
        get;
    }

    string Description
    {
        get;
    }

    string Version
    {
        get;
    }

    int VersionCode
    {
        get;
    }

    List<IComponent> Components()
    {
        return new List<IComponent>();
    }
}
