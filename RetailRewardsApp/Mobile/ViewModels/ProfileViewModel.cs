using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class ProfileViewModel
    {
        public ICommand GoToEditProfileCommand { get; }
        public ICommand GoToNotificationCommand { get; }
        public ICommand GoToHistoryCommand { get; }

        public ProfileViewModel() 
        {
            GoToEditProfileCommand = new Command(async () => await GoToEditProfile());
            GoToNotificationCommand = new Command(async () => await GoToNotification());
            GoToHistoryCommand = new Command(async () => await GoToHistory());

        }

        private async Task GoToEditProfile()
        {
            await Shell.Current.GoToAsync(nameof(EditProfilePage));
        }

        private async Task GoToNotification()
        {
            await Shell.Current.GoToAsync(nameof(NotificationDetailPage));
        }

        private async Task GoToHistory()
        {
            await Shell.Current.GoToAsync(nameof(HistoryDetailPage));
        }
    }
}       
