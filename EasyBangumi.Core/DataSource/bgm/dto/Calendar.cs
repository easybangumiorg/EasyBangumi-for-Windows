using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.bgm.dto;

namespace EasyBangumi.Core.DataSource.bgm.dto;


public class Weekday
{
    public string en
    {
        get; set;
    }

    public string cn
    {
        get; set;
    }

    public string ja
    {
        get; set;
    }

    public int id
    {
        get; set;
    }
}


public class Rating
{
    public int total
    {
        get; set;
    }

    public double score
    {
        get; set;
    }
}

public class Collection
{
    public int doing
    {
        get; set;
    }
}

public class ItemsItem
{
    public int id
    {
        get; set;
    }

    public string url
    {
        get; set;
    }

    public int type
    {
        get; set;
    }

    public string name
    {
        get; set;
    }

    public string name_cn
    {
        get; set;
    }

    public string summary
    {
        get; set;
    }

    public string air_date
    {
        get; set;
    }

    public int air_weekday
    {
        get; set;
    }

    public Rating rating
    {
        get; set;
    }

    public int rank
    {
        get; set;
    }

    public BangumiImages images
    {
        get; set;
    }

    public Collection collection
    {
        get; set;
    }
}

public class CalendarRoot
{
    public Weekday weekday
    {
        get; set;
    }

    public List<ItemsItem> items
    {
        get; set;
    }
}
