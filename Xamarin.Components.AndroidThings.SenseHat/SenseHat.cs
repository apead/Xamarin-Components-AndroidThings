namespace Xamarin.Components.AndroidThings.SenseHat
{
    public class SenseHat
    {
        public static int I2CAddress = 0x46;
        public static string BusDisplay = "I2C1";
        public static int DisplayWidth = LedMatrix.Width;
        public static int DisplayHeight = LedMatrix.Height;

        public static LedMatrix OpenDisplay()
        {
            return new LedMatrix(BusDisplay);
        }
    }
}