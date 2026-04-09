using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private User _user;
        [ObservableProperty]
        private ObservableCollection<Transaction> _transactions;
        [ObservableProperty]
        private ObservableCollection<Notification> _notifications;

        // XAML variable(s)
        [ObservableProperty]
        private string _fullName;

        public ProfileViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;

            User = _sessionService.LoggedInUser;
            Transactions = new ObservableCollection<Transaction>(User.Transactions);
            Notifications = new ObservableCollection<Notification>(User.Notifications);

            FullName = $"{User.FirstName} {User.LastName}";
        }



        // Command Implementation
        [RelayCommand]
        private async Task GoToEditProfile()
        {
            await Shell.Current.GoToAsync(nameof(EditProfilePage));
        }

        [RelayCommand]
        private async Task GoToNotification(Notification selectedNotification)
        {
            if (selectedNotification == null) return;

            var navParam = new Dictionary<string, object>
            {
                { "SelectedNotification", selectedNotification }
            };

            await Shell.Current.GoToAsync(nameof(NotificationDetailPage), navParam);
        }

        [RelayCommand]
        private async Task GoToTransaction(Transaction selectedTransaction)
        {
            if (selectedTransaction == null) return;

            var navParam = new Dictionary<string, object>
            {
                { "SelectedTransaction", selectedTransaction }
            };

            await Shell.Current.GoToAsync(nameof(TransactionDetailPage), navParam);
        }
    }
}