using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace RetailRewardsApp.Mobile.ViewModels
{

    // Page States
    public enum LoginState
    {
        Start, 
        Providers,
        EmailLogin,
        EmailRegister
    }


    public class LoginViewModel : INotifyPropertyChanged
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        private LoginState _currentState = LoginState.Start;

        // Binding vars
        private string _email { get; set; }
        private string _password { get; set; }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }
        public LoginState CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged();
                }
            }
        }
        
        // Command Inits
        public ICommand GoToHomeWithEmailCommand { get; }
        public ICommand GoToHomeWithAppleCommand { get; }
        public ICommand GoToHomeWithGoogleCommand { get; }
        public ICommand ChangeStateCommand { get; }

        public LoginViewModel(SessionService sessionService) 
        {
            _sessionService = sessionService;

            ChangeStateCommand = new Command<LoginState>((newState) =>
            {
                CurrentState = newState;
            });

            GoToHomeWithEmailCommand = new Command(async () => await GoToHomeWithEmail());
            GoToHomeWithAppleCommand = new Command(async () => await GoToHomeWithApple());
            GoToHomeWithGoogleCommand = new Command(async () => await GoToHomeWithGoogle());
        }

        private async Task GoToHomeWithEmail()
        {
            if (_sessionService.Login(Email, Password))
            {
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                return;
            }
        }

        private async Task GoToHomeWithApple()
        {
            var appleValidate = true;
            if (_sessionService.Login(appleValidate))
            {
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                return;
            }
        }

        private async Task GoToHomeWithGoogle()
        {
            var googleValidate = true;
            if (_sessionService.Login(googleValidate))
            {
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                return;
            }
        }

        // INotifyPropertyChanged invoker
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
