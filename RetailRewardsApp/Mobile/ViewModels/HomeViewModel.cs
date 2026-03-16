using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class HomeViewModel
    {
        // Service(s) and associated var(s)
        private readonly UserSessionService UserSessionService = new UserSessionService();
        UserService UserService = new UserService();
        User User;


        // Command Decs
        public ICommand GoToNotificationCommand { get; }
        public ICommand GoToHistoryCommand { get; }


        public HomeViewModel(UserSessionService userSessionService) 
        {
            UserSessionService = userSessionService;

            GoToNotificationCommand = new Command(async () => await GoToNotification());
            GoToHistoryCommand = new Command(async () => await GoToHistory());
        }


        // Navigation Functions
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
