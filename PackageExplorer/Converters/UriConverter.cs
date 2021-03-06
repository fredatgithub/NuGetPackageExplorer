﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PackageExplorer
{
    public class UriConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = (Uri) value;
            return uri == null ? null : uri.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string) value;
            if (String.IsNullOrEmpty(stringValue))
            {
                return null;
            }
            else
            {
                Uri uri;
                if (Uri.TryCreate(stringValue, UriKind.Absolute, out uri))
                {
                    return uri;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
        }

        #endregion
    }
}