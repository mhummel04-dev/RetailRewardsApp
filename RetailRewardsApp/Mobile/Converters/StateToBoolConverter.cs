using RetailRewardsApp.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RetailRewardsApp.Mobile.Converters
{
    public class StateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LoginState currentState && parameter is string targetState)
            {
                return currentState.ToString() == targetState;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
