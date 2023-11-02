using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CrossplatformSample.Desktop.Extensions;
using CrossplatformSample.Desktop.Views;
using CrossplatformSample.Extensions;
using CrossplatformSample.ViewModels;
using CrossplatformSample.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CrossplatformSample.Desktop;

public partial class App : Application
{
    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var provider = new ServiceCollection()
                .AddSharedServices()
                .BuildServiceProvider();
            
            Resources["mainView"] = new MainViewModel(provider)
                .SetView(new MainView())
                .View;
            
            desktop.MainWindow = new MainWindow();
            desktop.MainWindow.UpdateSize(0.8f, 0.8f);
        }

        base.OnFrameworkInitializationCompleted();
    }
}