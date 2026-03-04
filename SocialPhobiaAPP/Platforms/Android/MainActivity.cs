using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SocialPhobiaAPP
{
    
    [Activity(Theme = "@style/Maui.SplashTheme", ResizeableActivity = true, MainLauncher = true, LaunchMode = LaunchMode.SingleTask, ConfigurationChanges = ConfigChanges.ScreenSize |                                
                                 ConfigChanges.UiMode)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
