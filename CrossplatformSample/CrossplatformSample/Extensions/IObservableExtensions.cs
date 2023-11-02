using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace CrossplatformSample.Extensions;

public static class IObservableExtensions
{
    public static IDisposable ApplyStyleWhen<TValue>(this IObservable<TValue> observable,
        IStyleHost styleHost,
        Predicate<TValue> p,
        IStyle style)
    {
        var applied = false;
        
        return observable.Subscribe(value =>
            {
                if (p(value))
                {
                    if (applied)
                        return;
                    
                    styleHost.Styles.Add(style);
                    applied = true;
                }
                else if (applied)
                {
                    styleHost.Styles.Remove(style);
                    applied = false;
                }
            });
    }

    public static IDisposable ApplyStyleWhen<TValue>(this IObservable<TValue> observable,
        IStyleHost styleHost,
        Predicate<TValue> p,
        Uri styleUri)
    {
        var xaml = AvaloniaXamlLoader.Load(styleUri);

        if (xaml is not IStyle style)
            throw new Exception($"The axaml that you have loaded isn't a {nameof(IStyle)} element...");

        return observable.ApplyStyleWhen(styleHost, p, style);
    }
}