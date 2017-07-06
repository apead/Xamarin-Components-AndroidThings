using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Java.IO;

namespace Samples.Bmp180.EnvironmentSensor
{
    [Activity(Label = "Samples.Bmp180.EnvironmentSensor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            InitSensor();

            //// Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            //var button = FindViewById<Button>(Resource.Id.button1);

            //button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            var tempature = FindViewById<Button>(Resource.Id.TemperatureLabel);
            float temp = _bmp180.ReadTemperature();

            tempature.Text = string.Format("{0:0,0.0000000}", temp);
        }

        private Bmp180Sensor _bmp180;
        private const string I2CBus = "I2C1";
    
    private void InitSensor()
        {
            _bmp180 = new Bmp180Sensor(I2CBus);
        }

        private void ReadData()
        {
            try
            {
                float temp = _bmp180.ReadTemperature();
                float press = _bmp180.ReadPressure();
                double alt = _bmp180.ReadAltitude();
                Log.Debug("Test", "loop: temp " + temp + " alt: " + alt + " press: " + press);
            }
            catch (IOException e)
            {
                Log.Error("Test", "Sensor loop  error : ", e);
            }
        }

        private void CloseSensor()
        {
            try
            {
                _bmp180.Close();
            }
            catch (IOException e)
            {
                Log.Error("Test", "closeSensor  error: ", e);
            }
            _bmp180 = null;
        }
    }
}

