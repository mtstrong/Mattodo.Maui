
namespace Mattodo.Maui;

class App : Application
{
    public App(AppShell shell)
    {
        Resources.MergedDictionaries.Add(new Mattodo.Maui.Resources.Styles.Colors());
        Resources.MergedDictionaries.Add(new Mattodo.Maui.Resources.Styles.Styles());

        MainPage = shell;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        if(DeviceInfo.Platform == DevicePlatform.WinUI || DeviceInfo.Platform == DevicePlatform.macOS)
        {
            const int newWidth = 800;
            const int newHeight = 1200;
            
            window.Width = newWidth;
            window.Height = newHeight;
        }

        return window;
    }

    protected override void OnStart()
    {
        base.OnStart();
        
        Trace.WriteLine("*****App Started*****");
    }

    protected override void OnResume()
    {
        base.OnResume();
        
        Trace.WriteLine("*****App Resumed*****");
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        
        Trace.WriteLine("*****App Backgrounded*****");
    }
}
