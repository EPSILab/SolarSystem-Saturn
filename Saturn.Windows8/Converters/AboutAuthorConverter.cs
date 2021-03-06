﻿using System;
using Windows.UI.Xaml.Data;
using EPSILab.SolarSystem.Saturn.Windows8.Resources;

namespace EPSILab.SolarSystem.Saturn.Windows8.Converters
{
    /// <summary>
    /// A converter used by the About page.
    /// Display informations below the passed parameter
    /// </summary>
    public sealed class AboutAuthorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
            {
                return string.Format(FormatsRsxAccessor.GetString("Copyright"), value);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}