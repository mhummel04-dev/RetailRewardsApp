using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private User _user;
        [ObservableProperty]
        private ObservableCollection<Notification> _notifications;
        [ObservableProperty]
        private ObservableCollection<Transaction> _purchaseHistory;



        public HomeViewModel(SessionService sessionService) 
        {
            _sessionService = sessionService;
            _user = _sessionService.LoggedInUser;
            _notifications = new ObservableCollection<Notification>(_user.Notifications);
            _purchaseHistory = new ObservableCollection<Transaction>(_user.Transactions);
        }


        // Command Implementation
        [RelayCommand]
        private async Task GoToNotification(Notification selectedNotification)
        {
            if (selectedNotification == null) { return; }

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedNotification", selectedNotification }
            };

            await Shell.Current.GoToAsync(nameof(NotificationDetailPage), navigationParameter);
        }

        [RelayCommand]
        private async Task GoToTransaction(Transaction selectedTransaction)
        {
            if (selectedTransaction == null) { return; }

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedTransaction", selectedTransaction }
            };

            await Shell.Current.GoToAsync(nameof(TransactionDetailPage), navigationParameter);
        }
    }
}
