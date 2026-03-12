using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class OfferViewModel
    {
        public ICommand GoToOfferDetailCommand { get; }

        public OfferViewModel() 
        {
            GoToOfferDetailCommand = new Command(async () => await GoToOfferDetail());
        }

        private async Task GoToOfferDetail()
        {
            await Shell.Current.GoToAsync(nameof(OfferDetailPage));
        }
    }
}
