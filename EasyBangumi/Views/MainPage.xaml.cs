using EasyBangumi.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace EasyBangumi.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
