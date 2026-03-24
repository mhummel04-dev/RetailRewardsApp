using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class LoginViewModel
    {
        // Service(s) and associated var(s)
        private readonly SessionService SessionService;    

        // Binding vars
        public string Email { get; set; }
        public string Password { get; set; }
        
        // Command Inits
        public ICommand GoToControlCommand { get; }

        public LoginViewModel(SessionService sessionService) 
        {
            SessionService = sessionService;


            GoToControlCommand = new Command(async () => await GoToControl());
        }

        private async Task GoToControl()
        {
            if (SessionService.Login(Email, Password))
            {
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                return;
            }
        }
    }
}
