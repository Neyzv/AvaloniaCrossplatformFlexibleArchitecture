using System;
using Avalonia.Controls;
using CrossplatformSample.Extensions;
using ReactiveUI;

namespace CrossplatformSample.ViewModels;

public class ResponsiveViewModel : ViewModelBase
{
    public override ViewModelBase SetView(Control view)
    {
        view.WhenAnyValue(x => x.Bounds.Width)
            .ApplyStyleWhen(view, x => x < 850,
                new Uri("avares://CrossplatformSample/Assets/Styles/Responsiveness/Little.axaml"));
        
        return base.SetView(view);
    }
}