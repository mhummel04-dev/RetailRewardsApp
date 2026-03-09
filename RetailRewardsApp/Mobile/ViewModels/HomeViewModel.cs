using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class HomeViewModel
    {
        public ICommand GoToNotificationCommand { get; }

        public HomeViewModel() 
        {
            GoToNotificationCommand = new Command(async () => await GoToNotification());
        }

        private async Task GoToNotification()
        {
            await Shell.Current.GoToAsync(nameof(NotificationDetailPage));
        }
    }
}
