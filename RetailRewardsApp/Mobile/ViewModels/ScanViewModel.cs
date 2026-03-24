using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class ScanViewModel : INotifyPropertyChanged
    {
        // Service(s) and associated var(s)
        private readonly SessionService SessionService;
        private User _user;
        
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


        public ScanViewModel(SessionService sessionService) 
        {
            SessionService = sessionService;
            BindingUser = SessionService.LoggedInUser;
        }


        // INotifyPropertyChanged invoker
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
