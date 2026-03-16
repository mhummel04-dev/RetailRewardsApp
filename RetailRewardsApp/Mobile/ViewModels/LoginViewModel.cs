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
        UserSessionService UserSessionService = new UserSessionService();     
        UserService UserService = new UserService();

        // Binding vars
        public string Email { get; set; }
        public string Password { get; set; }
        
        // Command Inits
        public ICommand GoToControlCommand { get; }

        public LoginViewModel(UserSessionService userSessionService) 
        {
            UserSessionService = userSessionService;

            GoToControlCommand = new Command(async () => await GoToControl());
        }

        private async Task GoToControl()
        {
            if (UserSessionService.Login(Email, Password))
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
