using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource.Models;
public class BangumiSummary
{
    public int ID;

    public string Name; // 名称

    public string Cover; // 大图

    public string CoverGrid; // 方图

    public string Date; // 上线日期

    public string Summary; // 简介

    public Dictionary<string, int> Tags; // 标签

    public Dictionary<string, string> Info; // 其他信息

    public double Score; // 分数

    public int TotalEpisodes; // 总集数

    public bool IsNSFW; // 是否色情

    public double FiveScore => Score / 2; // 转成5分制

    public List<InfoPair> GetInfo
    {
        get
        {
            var infos = new List<InfoPair>();

            foreach (var tag in Info)
            {
                infos.Add(new InfoPair()
                {
                    Subject = tag.Key,
                    Content = tag.Value
                });
            }

            return infos;
        }
    }

    public string ParseTags
    {
        get
        {
            var tag = "";

            foreach (var item in Tags)
            {
                tag += $"{item.Key}-{item.Value}  ";
            }

            return tag;
        }
    }
}


public class Tag
{
    public string Name;
    public int Count;
}

public class InfoPair
{
    public string Subject;
    public string Content;
}