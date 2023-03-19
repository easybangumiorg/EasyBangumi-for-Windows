using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBangumi.Core.Contracts.Services;
using EasyBangumi.Core.DataSource;
using EasyBangumi.Core.DataSource.Contracts;
using EasyBangumi.Core.DataSource.Models;
using EasyBangumi.Core.Exceptions;
using EasyBangumi.Core.Models;

namespace EasyBangumi.Core.Services;
public class DataSourceService : IDataSourceService
{
    private readonly DataSourceSelector _source = new();


    public DataSourceSummary DataSource => new(_source.Target);
    public List<DataSourceSummary> GetAllDataSource()
    {
        var list = new List<DataSourceSummary>();
        _source.Sources.ForEach(source =>
        {
            list.Add(new DataSourceSummary(source));
        });
        return list;
    }
    public bool ChooseDataSource(int target) => _source.Select(target);
    public bool CanUseBangumiInfo => _source.Target is IBangumiInfo;
    public bool CanUseBangumiInfoExtended => _source.Target is IBangumiInfoExtended;

    public async Task<BangumiSummary> GetInfo(BangumiCoverSummary Cover)
    {
        var source = CanUseBangumiInfo ?
            _source.Target as IBangumiInfo :
            throw new MethodNotImplementedException("GetInfo");

        try
        {
            return await source.GetBangumiByID(Cover.ID);
        }
        catch (IndexBangumiUncompleteException ex)
        {
            switch (ex.Reason)
            {
                case ExceptionType.NothingFind:
                    Console.WriteLine($"未能找到ID: {ex.Message}");
                    break;
                default:
                    Console.WriteLine($"{ex.Message}");
                    break;
            }
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new InternalException(ex, ExceptionType.Unknown);
        }
    }

    public async Task<BangumiCoverCollection> Search(string keyword, int point = 0)
    {
        var source = CanUseBangumiInfo ?
            _source.Target as IBangumiInfo :
            throw new MethodNotImplementedException("Search");

        try
        {
            return await source.Search(keyword, point);
        }
        catch (SearchUncompleteException ex)
        {
            switch (ex.Reason)
            {
                case ExceptionType.OutOfRange:
                    Console.WriteLine($"搜索超出索引: {ex.Message}");
                    break;
                case ExceptionType.NothingFind:
                    Console.WriteLine($"搜索未找到: {ex.Message}");
                    break;
                default:
                    Console.WriteLine($"{ex.Message}");
                    break;
            }
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new InternalException(ex, ExceptionType.Unknown);
        }
    }

    private BangumiCalendar _calendar = null;

    public async Task<BangumiCoverCollection> DailyUpdate()
    {
        _ = CanUseBangumiInfo ?
            _source.Target as IBangumiInfo :
            throw new MethodNotImplementedException("DailyUpdate");

        if (_calendar is null)
        {
            await Calendar();
        }

        // 取昨天更新的
        var dayOfWeek = (Convert.ToInt32(DateTime.Now.DayOfWeek) + 5) % 7;

        return _calendar[dayOfWeek];
    }

    public async Task<BangumiCoverCollection> DailyUpdate(int Week)
    {
        _ = CanUseBangumiInfo ?
            _source.Target as IBangumiInfo :
            throw new MethodNotImplementedException("DailyUpdate");

        if (_calendar is null)
        {
            await Calendar();
        }

        return _calendar[Week + 1];
    }

    public async Task<BangumiCalendar> Calendar()
    {
        var source = CanUseBangumiInfo ?
            _source.Target as IBangumiInfo :
            throw new MethodNotImplementedException("DailyUpdate");

        try
        {
            _calendar = await source.Calendar();
            return _calendar;
        }
        catch (CalendarUncompleteException ex)
        {
            switch (ex.Reason)
            {
                case ExceptionType.NotExpect:
                    Console.WriteLine($"返回了个意料之外的值: {ex.Message}");
                    break;
                default:
                    Console.WriteLine($"{ex.Message}");
                    break;
            }
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new InternalException(ex, ExceptionType.Unknown);
        }
    }

}
