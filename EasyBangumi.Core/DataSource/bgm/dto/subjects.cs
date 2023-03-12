using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.bgm.dto;

namespace EasyBangumi.Core.DataSource.bgm.dto;

public class Images2
{
    /// <summary>
    /// 
    /// </summary>
    public string small
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string grid
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string large
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string medium
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string common
    {
        get; set;
    }
}

public class TagsItem
{
    /// <summary>
    /// 柯南
    /// </summary>
    public string name
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int count
    {
        get; set;
    }
}

public class InfoboxItem
{
    /// <summary>
    /// 中文名
    /// </summary>
    public string key
    {
        get; set;
    }
    /// <summary>
    /// 名侦探柯南
    /// </summary>
    public string value
    {
        get; set;
    }
}


public class Rating2
{
    /// <summary>
    /// 
    /// </summary>
    public int rank
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int total
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public double score
    {
        get; set;
    }
}

public class Collection2
{
    /// <summary>
    /// 
    /// </summary>
    public int on_hold
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int dropped
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int wish
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int collect
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int doing
    {
        get; set;
    }
}

public class SubjectRoot
{
    /// <summary>
    /// 
    /// </summary>
    public string date
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string platform
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public Images2 images
    {
        get; set;
    }
    /// <summary>
    /// 主角工藤新一原本是一位颇具名声的高中生侦探，在目击黑暗组织的地下交易后，正准备追踪时却被突袭击昏，并被灌下代号为“APTX4869”（アポトキシン4869）的不明药物。后来虽然幸免于死，但身体就此缩小为小学时期的模样。之后他化名为江户川柯南，在邻居阿笠博士的建议下，寄住在女友毛利兰的父亲—侦探毛利小五郎家中，继续秘密从事追查黑暗组织的工作，并私下探寻获得解药的管道，希望能够恢复原来新一的样貌。与此同时，柯南凭着自己的推理天份，配合阿笠博士为他发明的道具，帮助毛利小五郎成为出名的大侦探。故事内容当中穿插许多爱情、友情、犯罪、背叛、复仇等情节。
    /// </summary>
    public string summary
    {
        get; set;
    }
    /// <summary>
    /// 名探偵コナン
    /// </summary>
    public string name
    {
        get; set;
    }
    /// <summary>
    /// 名侦探柯南
    /// </summary>
    public string name_cn
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public List<TagsItem> tags
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public List<InfoboxItem> infobox
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public Rating2 rating
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int total_episodes
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public Collection2 collection
    {
        get; set;
    }
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
    public int eps
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public int volumes
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string locked
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    public string nsfw
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
}

