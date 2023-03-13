using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource.bgm.dto;

public class SearchListItem
{
    /// <summary>
    /// 
    /// </summary>
    public int id
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string url
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int type
    {
        get; set;
    }
    /// <summary>
    /// 転生王女と天才令嬢の魔法革命
    /// </summary>
    public string name
    {
        get; set;
    }
    /// <summary>
    /// 转生公主与天才千金的魔法革命
    /// </summary>
    public string name_cn
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string summary
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string air_date
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int air_weekday
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public BangumiImages images
    {
        get; set;
    }
}

public class SearchSubjectRoot
{
    /// <summary>
    /// 
    /// </summary>
    public int results
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public List<SearchListItem> list
    {
        get; set;
    }
}

