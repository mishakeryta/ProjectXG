using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjectXG
{
    [ValueConversion(typeof(ImageBackgroundColor), typeof(Brushes))]
    class HeaderToBackgroundConverter : IValueConverter
    {
        public static HeaderToBackgroundConverter Instance = new HeaderToBackgroundConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ImageBackgroundColor)value)
            {
                case ImageBackgroundColor.Blue:return Brushes.Blue;
                default:return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
