// See https://aka.ms/new-console-template for more information'
using EasyBangumi.Core.DataSource.bgm;

var bgm = new Bgmtv();

async Task TestCalendar()
{
    var calendar = await bgm.Calendar();

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
    var summary = await bgm.GetBangumiByID(296739);

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
    var summary = await bgm.Search("转生王女");

    Console.WriteLine("\n----- 搜索 -----");
    foreach (var item in summary)
    {
        Console.WriteLine($"{item.ID}: {item.Name}");
    }
}

await TestSearch();
