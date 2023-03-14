using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.Summary;

namespace EasyBangumi.Core.DataSource.Contracts;

public interface IDataSource
{
    string Key // 内部标签名称
    {
        get;
    }

    string Label // 显示标签名称
    {
        get;
    }

    string Version // 版本号
    {
        get;
    }

    int VersionCode // 版本号，数字版
    {
        get;
    }

    string Description // 描述
    {
        get;
    }

    string OfficialWebsite // 官方网站
    {
        get;
    }
}