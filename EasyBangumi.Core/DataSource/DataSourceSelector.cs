using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.DataSource.bgm;
using EasyBangumi.Core.DataSource.Contracts;

namespace EasyBangumi.Core.DataSource;
public class DataSourceSelector
{
    public readonly List<IDataSource> Sources;

    public bool Select(int target)
    {
        if (target > Sources.Count || target < 0)
        {
            _target = target;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Length => Sources.Count;
    public IDataSource Target => Sources[_target]; 

    private int _target = 0;

    public DataSourceSelector()
    {
        Sources = new List<IDataSource>() {
            new Bgmtv(),
        };
    }
}
