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
using RetailRewardsApp.Core.Interfaces;

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

        private readonly IAIService _aiService;

        public HomeViewModel(SessionService sessionService, IAIService aiService) 
        {
            _sessionService = sessionService;
            _user = _sessionService.LoggedInUser;
            _notifications = new ObservableCollection<Notification>(_user.Notifications);
            _purchaseHistory = new ObservableCollection<Transaction>(_user.Transactions);


            _aiService = aiService;

            // This is a quick fire-and-forget test
            Task.Run(async () => {
                var reply = await _aiService.GetResponseAsync("Give me a one-sentence retail greeting.");
                System.Diagnostics.Debug.WriteLine($"[AI TEST]: {reply}");
            });
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
