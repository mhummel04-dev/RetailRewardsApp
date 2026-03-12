using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class MenuViewModel
    {
        public ICommand GoToItemDetailCommand { get; }

        public MenuViewModel() 
        {
            GoToItemDetailCommand = new Command(async () => await GoToItemDetail());
        }

        private async Task GoToItemDetail()
        {
            await Shell.Current.GoToAsync(nameof(ItemDetailPage));
        }
    }
}
