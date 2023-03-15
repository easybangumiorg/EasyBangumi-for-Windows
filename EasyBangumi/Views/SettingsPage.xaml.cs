﻿using EasyBangumi.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace EasyBangumi.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }
}
