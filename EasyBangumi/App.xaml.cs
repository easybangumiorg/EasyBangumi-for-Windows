using EasyBangumi.Activation;
using EasyBangumi.Contracts.Services;
using EasyBangumi.Core.Contracts.Services;
using EasyBangumi.Core.Services;
using EasyBangumi.Helpers;
using EasyBangumi.Models;
using EasyBangumi.Notifications;
using EasyBangumi.Services;
using EasyBangumi.ViewModels;
using EasyBangumi.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace EasyBangumi;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>(); // 启动处理器

            // Other Activation Handlers
            services.AddTransient<IActivationHandler, AppNotificationActivationHandler>(); // 通知处理器

            // Services
            services.AddSingleton<IAppNotificationService, AppNotificationService>(); // 通知服务
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();     // 本地设置服务
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();     // 主题服务
            services.AddTransient<INavigationViewService, NavigationViewService>();   // 导航控件服务
            services.AddSingleton<IActivationService, ActivationService>(); // 激活服务
            services.AddSingleton<IPageService, PageService>();             // 页面服务
            services.AddSingleton<INavigationService, NavigationService>(); // 导航服务

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>(); // 示例数据生成器
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IDataSourceService, DataSourceService>(); // 数据源服务

            // Views and ViewModels
            services.AddTransient<BangumiDetailViewModel>();
            services.AddTransient<BangumiDetailPage>();

            // 主视图和视图模型
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        App.GetService<IAppNotificationService>().Initialize();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        // 一个示例的通知
        // App.GetService<IAppNotificationService>().Show(string.Format("AppNotificationSamplePayload".GetLocalized(), AppContext.BaseDirectory));

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
