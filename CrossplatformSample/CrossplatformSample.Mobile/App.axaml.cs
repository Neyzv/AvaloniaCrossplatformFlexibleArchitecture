using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CrossplatformSample.Extensions;
using CrossplatformSample.ViewModels;
using CrossplatformSample.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CrossplatformSample.Mobile;

public partial class App : Application
{
    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var provider = new ServiceCollection()
                .AddSharedServices()
                .BuildServiceProvider();
            
            singleViewPlatform.MainView = new MainViewModel(provider)
                .SetView(new MainView())
                .View;
        }

        base.OnFrameworkInitializationCompleted();
    }
}