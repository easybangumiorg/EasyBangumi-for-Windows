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

await TestCalendar();
