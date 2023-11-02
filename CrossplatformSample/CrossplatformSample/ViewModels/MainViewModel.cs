using System;
using System.Reactive.Linq;
using System.Windows.Input;
using CrossplatformSample.Services;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CrossplatformSample.ViewModels;

public class MainViewModel : ResponsiveViewModel
{
    private string _greeting = "Welcome to Avalonia";
    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
    
    private string _bufferedGreeting = string.Empty;
    public string BufferedGreeting
    {
        get => _bufferedGreeting;
        set => this.RaiseAndSetIfChanged(ref _bufferedGreeting, value);
    }

    private string _serviceComposed = string.Empty;
    public string ServiceComposed
    {
        get => _serviceComposed;
        set => this.RaiseAndSetIfChanged(ref _serviceComposed, value);
    }

    private bool _isVisible;

    public bool IsVisible
    {
        get => _isVisible;
        set => this.RaiseAndSetIfChanged(ref _isVisible, value);
    }
    
    public ICommand? ShowCommand { get; }
    
    public MainViewModel() {}

    public MainViewModel(IServiceProvider provider)
    {
        BufferedGreeting = _greeting;

        ServiceComposed = string.Join(' ', provider.GetRequiredService<ISampleService>()
            .GetDatas());
        
        // actualize Greeting every 400ms
        this.WhenAnyValue(x => x.BufferedGreeting)
            .Throttle(TimeSpan.FromMilliseconds(400))
            .ObserveOn(RxApp.MainThreadScheduler) // execute on UI Thread
            .Subscribe((value) => Greeting = value);

        ShowCommand = ReactiveCommand.Create(() =>
        {
            IsVisible = !IsVisible;
        });
    }
}