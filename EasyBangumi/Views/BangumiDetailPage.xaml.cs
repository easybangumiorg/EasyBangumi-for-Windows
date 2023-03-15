using CommunityToolkit.WinUI.UI.Animations;

using EasyBangumi.Contracts.Services;
using EasyBangumi.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace EasyBangumi.Views;

public sealed partial class BangumiDetailPage : Page
{
    public BangumiDetailViewModel ViewModel
    {
        get;
    }

    public BangumiDetailPage()
    {
        ViewModel = App.GetService<BangumiDetailViewModel>();
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Item != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
