// See https://aka.ms/new-console-template for more information'
using EasyBangumi.Core.DataSource;
using EasyBangumi.Core.DataSource.Contracts;
using EasyBangumi.Core.Services;
using EasyBangumi.Core.DataSource.Summary;

var dss = new DataSourceService();

async Task TestCalendar()
{
    var calendar = await dss.Calendar();

    calendar.ForEach(it =>
    {
        Console.WriteLine("-----");

        it.ForEach(it2 =>
        {
            Console.WriteLine(it2.Name);
        });
    });
}

async Task TestGetBgmByID()
{
    var summary = await dss.GetInfo(new BangumiCoverSummary() { ID = 395714 });
    Console.WriteLine(summary.Name);
    Console.WriteLine(summary.Summary);
    Console.WriteLine("\n----- 番剧信息 -----");
    foreach (var item in summary.Info)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}

async Task TestSearch()
{
    var summary = await dss.Search("转生王女");

    Console.WriteLine("\n----- 搜索 -----");
    foreach (var item in summary)
    {
        Console.WriteLine($"{item.ID}: {item.Name}");
    }

}


async Task TestException()
{
    await dss.Search("水");
    //await dss.Search("水", 1001);

    //await dss.GetInfo(new EasyBangumi.Core.DataSource.Summary.BangumiCoverSummary() { ID = 1145141919 });

    //await dss.Calendar();

    var today = await dss.DailyUpdate();
    Console.WriteLine("----- 今日更新 -----");
    today.ForEach(bgm => { 
        Console.WriteLine($"{bgm.Name}");
    });

}

await TestException();
