using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfExample.App.Converters
{
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool)
                throw new InvalidCastException($"{nameof(value)} wasn't a bool value");

            var isVisible = (bool)value;

            if (Invert)
                isVisible = !isVisible;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Visibility)
                throw new InvalidCastException($"{nameof(value)} wasn't of type {nameof(Visibility)}");

            var visibility = (Visibility)value;

            bool booleanValue;
            switch (visibility)
            {
                case Visibility.Visible:
                    booleanValue = true;
                    break;
                case Visibility.Collapsed:
                case Visibility.Hidden:
                    booleanValue= false;
                    break;
                default:
                    throw new InvalidCastException($"The {nameof(Visibility)} value of {visibility} doesn't have a boolean mapping");
            }

            return Invert ? !booleanValue : booleanValue;
        }
    }
}
