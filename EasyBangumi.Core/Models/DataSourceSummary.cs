using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.Contracts;

namespace EasyBangumi.Core.Models;
public class DataSourceSummary : IDataSource
{

    public string Key // 内部标签名称
    {
        get;
    }
    public string Label // 显示标签名称
    {
        get;
    }
    public string Version // 版本号
    {
        get;
    }
    public int VersionCode // 版本号，数字版
    {
        get;
    }
    public string Description // 描述
    {
        get;
    }
    public string OfficialWebsite // 官方网站
    {
        get;
    }
    public bool CanUseBangumiInfo
    {
        get;
    }
    public bool CanUseBangumiInfoExtended
    {
        get;
    }

    public DataSourceSummary(IDataSource dataSource)
    {
        Key = dataSource.Key;
        Label = dataSource.Label;
        Version = dataSource.Version;
        VersionCode = dataSource.VersionCode;
        Description = dataSource.Description;
        OfficialWebsite = dataSource.OfficialWebsite;
        CanUseBangumiInfo = dataSource is IBangumiInfo;
        CanUseBangumiInfoExtended = dataSource is IBangumiInfoExtended;
    }
}
