using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class OfferViewModel
    {
        // Service(s) and associated var(s)
        private readonly SessionService SessionService;
        private Core.Models.Location Location;
        private ObservableCollection<Offer> _offers;


        // Command Declarations
        public ICommand GoToOfferDetailCommand { get; }


        // Binding Variables
        public ObservableCollection<Offer> BindingOffers { get =>  _offers; set
            {
                if (_offers != value)
                {
                    _offers = value;
                    OnPropertyChanged();
                }
            } 
        }

        public OfferViewModel(SessionService sessionService) 
        {

            SessionService = sessionService;
            Location = SessionService.RegisteredLocation;
            BindingOffers = new ObservableCollection<Offer>(Location.Offers);


            GoToOfferDetailCommand = new Command(async () => await GoToOfferDetail());
        }

        private async Task GoToOfferDetail()
        {
            await Shell.Current.GoToAsync(nameof(OfferDetailPage));
        }


        // INotifyPropertyChanged invoker
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
