using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class LoginViewModel
    {
        public ICommand GoToControlCommand { get; }

        public LoginViewModel() 
        {
            GoToControlCommand = new Command(async () => await GoToControl());
        }

        private async Task GoToControl()
        {
            await Shell.Current.GoToAsync("//main");
        }
    }
}
