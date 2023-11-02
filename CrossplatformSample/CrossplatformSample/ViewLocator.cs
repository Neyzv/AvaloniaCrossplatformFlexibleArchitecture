using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CrossplatformSample.ViewModels;

namespace CrossplatformSample;

public class ViewLocator : IDataTemplate
{
    private static readonly TextBlock DefaultViewComponent = new()
    {
        Text = "Unable to find associated view..."
    };

    public Control Build(object? data) =>
        data is ViewModelBase vm ? 
                vm.View ?? DefaultViewComponent
            : DefaultViewComponent;

    public bool Match(object? data) =>
        data is ViewModelBase;
}