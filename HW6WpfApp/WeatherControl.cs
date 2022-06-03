using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW6WpfApp
{
    enum Precipitation
        {
            sunny,
            cloudy,
            rainy,
            snowy
        }
    class WeatherControl: DependecyObject
    {
        private string windDirection;
        private int windSpeed;
        private Precipitation Precipitation;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public WeatherControl(string windDir, int windSp, Precipitation precipitation)
        {
            this.WindDirection = windDir;
            this.WindSpeed = windSp;
            this.Precipitation = precipitation;
        }
        public static readonly DependecyProperty TempProperty;
        public int Temp 
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        

        static WeatherControl()
        {
            TempProperty = DependecyProperty.Register(
             nameof(Temp),
             typeof(int),
             typeof(WeatherControl),
             new FrameworkPropertyMetadata(
                 0,
                 FrameworkPropertyMetadataOptions.AffectsMeasure |
                 FrameworkPropertyMetadataOptions.AffectsRender,
                 null,
                 new CoerceValueCallback(CoerceTemp),
             new ValidateValueCallback(ValidateTemp));
        }
        private static bool ValidateTemp(object value)
        {
            int v=(int)value;
            if (v>=-50 && v<=50)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        private static object CoerceTemp(DependecyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v>=-50 && v<=50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }


    }

   
}
