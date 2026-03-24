using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class ProfileViewModel
    {
        //Service(s) and associated var(s)
        private readonly SessionService SessionService;
        private User _user;
        private ObservableCollection<Transaction> _transactions;
        private ObservableCollection<Notification> _notifications;

        // Command Declarations
        public ICommand GoToEditProfileCommand { get; }
        public ICommand GoToNotificationCommand { get; }
        public ICommand GoToHistoryCommand { get; }


        // Binding Variables
        public User BindingUser { get => _user; set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Transaction> BindingTransactions { get =>  _transactions; set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged();
                }
            } 
        }

        public ObservableCollection<Notification> BindingNotifications { get => _notifications; set
            {
                if (_notifications != value)
                {
                    _notifications = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProfileViewModel(SessionService sessionService) 
        {

            SessionService = sessionService;
            BindingUser = SessionService.LoggedInUser;
            BindingTransactions = new ObservableCollection<Transaction>(BindingUser.Transactions);
            BindingNotifications = new ObservableCollection<Notification>(BindingUser.Notifications);


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


        // INotifyPropertyChanged invoker
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}       
