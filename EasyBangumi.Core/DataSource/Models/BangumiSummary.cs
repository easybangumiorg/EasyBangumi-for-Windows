using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.DataSource.Summary;
public class BangumiSummary
{
    public int ID;

    public string Name;

    public string Cover;

    public string CoverGrid;

    public string Date;

    public string Summary;

    public Dictionary<string, int> Tags;

    public Dictionary<string, string> Info;

    public double Score;

    public int TotalEpisodes;

    public bool IsNSFW;
}
