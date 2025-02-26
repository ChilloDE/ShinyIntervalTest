using Android.App;
using Android.Content.PM;
using Android.OS;
using Shiny;

namespace ShinyIntervalTest;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize
        | ConfigChanges.Orientation
        | ConfigChanges.UiMode
        | ConfigChanges.ScreenLayout
        | ConfigChanges.SmallestScreenSize
        | ConfigChanges.Density)]
[IntentFilter(
    [ ShinyNotificationIntents.NotificationClickAction ],
    Categories = [ "andoird.intent.category.DEFAULT" ])]
public class MainActivity : MauiAppCompatActivity
{
}
