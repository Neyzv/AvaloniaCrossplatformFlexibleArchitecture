using Avalonia.Controls;

namespace CrossplatformSample.Desktop.Extensions;

public static class WindowExtensions
{
    public static void UpdateSize(this Window window,
        float xPercent, float yPercent)
    {
        window.Width = xPercent * window.Screens.Primary!.WorkingArea.Width;
        window.Height = yPercent * window.Screens.Primary!.WorkingArea.Height;
    }
}