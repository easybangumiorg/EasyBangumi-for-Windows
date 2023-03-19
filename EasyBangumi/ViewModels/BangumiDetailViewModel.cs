using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyBangumi.Contracts.ViewModels;
using EasyBangumi.Core.Contracts.Services;
using EasyBangumi.Core.DataSource.Models;

namespace EasyBangumi.ViewModels;

public partial class BangumiDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDataSourceService _dataSourceService;

    [ObservableProperty]
    private BangumiSummary? _item;

    [ObservableProperty]
    private BangumiCoverSummary? _cover;

    public BangumiDetailViewModel(IDataSourceService dataSourceService)
    {
        _dataSourceService = dataSourceService;
    }

    public async Task GetBangumiDetailAsync()
    {
        // TODO: 异常处理
        Item = await _dataSourceService.GetInfo(Cover);
    }

    [RelayCommand]
    public void AddToSubscribe()
    {
        App.MainWindow.ShowMessageDialogAsync("TODO: 订阅番剧的方法。", "出错啦");
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is BangumiCoverSummary coverSummary)
        {
            Cover = coverSummary;
            await GetBangumiDetailAsync();
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
