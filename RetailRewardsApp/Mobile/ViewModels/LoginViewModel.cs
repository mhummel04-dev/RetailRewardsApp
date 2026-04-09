using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RetailRewardsApp.Mobile.ViewModels
{

    // Page States
    public enum LoginState
    {
        Start, 
        LoginProviders,
        RegisterProviders,
        EmailLogin,
        EmailRegister
    }


    public partial class LoginViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;


        // Binding variable(s)
        [ObservableProperty]
        private LoginState _currentState = LoginState.Start;

        // XAML variable(s)
        [ObservableProperty]
        private string _firstName, _lastName, _email, _password, _passwordVerified, _phoneNumber, _birthday;

             
        public LoginViewModel(SessionService sessionService) 
        {
            _sessionService = sessionService;
        }


        // Command Implementation
        [RelayCommand]
        private void ChangeState(LoginState newState)
        {
            CurrentState = newState;
        }

        [RelayCommand]
        private async Task GoToHomeWithEmail()
        {
            if (_sessionService.Login(_email, _password))
            {
                await Shell.Current.GoToAsync("//main");
            } 
        }

        [RelayCommand]
        private async Task GoToHomeWithApple()
        {
            var appleValidate = true;
            if (_sessionService.Login(appleValidate))
            {
                await Shell.Current.GoToAsync("//main");
            }
        }

        [RelayCommand]
        private async Task GoToHomeWithGoogle()
        {
            var googleValidate = true;
            if (_sessionService.Login(googleValidate))
            {
                await Shell.Current.GoToAsync("//main");
            }
        }

        [RelayCommand]
        private async Task SignUp()
        {
            User newUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Birthday = DateTime.Parse(Birthday),
                Points = 0
            };
            _sessionService.FakeDB.FakeUserTable.Add(newUser);

            if (_sessionService.Login(newUser.EmailAddress, newUser.Password))
            {
                await Shell.Current.GoToAsync("//main");
            }
        }
    }
}
