using CommunityToolkit.Mvvm.ComponentModel;

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

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is BangumiCoverSummary coverSummary)
        {
            _cover = coverSummary;
            // TODO: 异常处理
            Item = await _dataSourceService.GetInfo(coverSummary);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
