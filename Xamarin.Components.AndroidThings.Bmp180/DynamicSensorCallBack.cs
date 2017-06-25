using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Samgol.Driver.Bmp180;

namespace Xamarin.Bmp180
{
    public class DynamicSensorCallBack : SensorManager.DynamicSensorCallback
    {
        private SensorManager _sensorManager;
        private string TAG = "SensorManager";

        public DynamicSensorCallBack(SensorManager sensorManager)
        {
            _sensorManager = sensorManager;

        }

        public override void OnDynamicSensorConnected(Sensor sensor)
        {
            base.OnDynamicSensorConnected(sensor);

            if (sensor.StringType == Sensor.StringTypeAmbientTemperature)
            {
                Log.Info(TAG, "Temperature sensor connected");
                //      _sensorManager.RegisterListener(SensorActivity.this,
                //              sensor, SensorManager.SENSOR_DELAY_NORMAL);
            }
            else if (sensor.StringType == Sensor.StringTypePressure)
            {
                Log.Info(TAG, "Pressure sensor connected");
//                mSensorManager.registerListener(SensorActivity.this,
                //                       sensor, SensorManager.SENSOR_DELAY_NORMAL);
            }
        }

        public override void OnDynamicSensorDisconnected(Sensor sensor)
        {
            base.OnDynamicSensorDisconnected(sensor);
        }
    }
}