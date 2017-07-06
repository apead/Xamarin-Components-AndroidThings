using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Things.Pio;

namespace Xamarin.Components.AndroidThings.SenseHat
{
    public class LedMatrix
    {
        public static int Width = 8;
        public static int Height = 8;
        private static int _bufferSize = Width * Height * 3 + 1;
        private byte[] _buffer = new byte[_bufferSize];

        private I2cDevice _device;


        public LedMatrix(string bus)
        {
            var pioService = new PeripheralManagerService();
            _device
                =
                pioService.OpenI2cDevice
                    (bus, SenseHat.I2CAddress);
        }

        public void Close()
        {
            if (_device != null)
            {
                try
                {
                    _device.Close();
                }
                finally
                {
                    _device = null;
                }
            }
        }

        public void Draw(int color)
        {
            _buffer[0] = 0;
            var a = Color.GetAlphaComponent(color) / 255f;
            var r = (byte) ((int) (Color.GetRedComponent(color) * a) >> 3);
            var g = (byte) ((int) (Color.GetGreenComponent(color) * a) >> 3);
            var b = (byte) ((int) (Color.GetBlueComponent(color) * a) >> 3);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _buffer[1 + x + Width * 0 + 3 * Width * y] = r;
                    _buffer[1 + x + Width * 1 + 3 * Width * y] = g;
                    _buffer[1 + x + Width * 2 + 3 * Width * y] = b;
                }
            }
            _device.Write(_buffer, _buffer.Length);
        }

        public void Draw(Bitmap bitmap)
        {
         //   Bitmap dest = Bitmap.CreateScaledBitmap(bitmap, 8, 8, true);
            _buffer[0] = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int p = bitmap.GetPixel(x, y);
                    float a = Color.GetAlphaComponent(p) / 255f;
                    _buffer[1 + x + Width * 0 + 3 * Width * y] = (byte) ((int) (Color.GetRedComponent(p) * a) >> 3);
                    _buffer[1 + x + Width * 1 + 3 * Width * y] = (byte) ((int) (Color.GetGreenComponent(p) * a) >> 3);
                    _buffer[1 + x + Width * 2 + 3 * Width * y] = (byte) ((int) (Color.GetBlueComponent(p) * a) >> 3);
                }
            }
            _device.Write(_buffer, _buffer.Length);
        }

        public void Draw(Drawable drawable)
        {
            var bitmap = Bitmap.CreateBitmap(Width, Height,
                Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
        drawable.SetBounds(0, 0, Width, Height);
        drawable.Draw(canvas);
        Draw(bitmap);
    }
}
}