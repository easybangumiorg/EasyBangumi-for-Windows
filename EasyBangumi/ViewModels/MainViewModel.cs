using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyBangumi.Contracts.Services;
using EasyBangumi.Contracts.ViewModels;
using EasyBangumi.Core.Contracts.Services;
using EasyBangumi.Core.DataSource.Models;
using EasyBangumi.Core.Models;

namespace EasyBangumi.ViewModels;

public partial class MainViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IDataSourceService _dataSourceService;

    public ICommand ItemClickCommand
    {
        get;
    }

    public ObservableCollection<BangumiCoverSummary> Source { get; } = new ObservableCollection<BangumiCoverSummary>();

    public MainViewModel(INavigationService navigationService, IDataSourceService dataSourceService)
    {
        _navigationService = navigationService;
        _dataSourceService = dataSourceService;

        ItemClickCommand = new RelayCommand<BangumiCoverSummary>(OnItemClick);
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: 异常处理
        var data = await _dataSourceService.DailyUpdate();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnItemClick(BangumiCoverSummary? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(BangumiDetailViewModel).FullName!, clickedItem.ID);
        }
    }
}
