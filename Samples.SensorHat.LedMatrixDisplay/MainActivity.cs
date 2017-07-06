using Android.App;
using Android.OS;
using Xamarin.Components.AndroidThings.SenseHat;

namespace Sample.SensorHat
{
    [Activity(Label = "Sensor HAT Led Matrix Xamagon", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var display = SenseHat.OpenDisplay();

            display.Draw(GetDrawable(Resource.Drawable.xamarin2));
        }
    }
}

