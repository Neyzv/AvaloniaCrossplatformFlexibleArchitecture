using System;
using Avalonia.Controls;
using CrossplatformSample.Extensions;
using ReactiveUI;

namespace CrossplatformSample.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public Control? View { get; private set; }

    public virtual ViewModelBase SetView(Control view)
    {
        view.DataContext = this;
        View = view;
        
        return this;
    }
}