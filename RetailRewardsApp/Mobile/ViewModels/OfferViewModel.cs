using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class OfferViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private Core.Models.Location _location;
        [ObservableProperty]
        private ObservableCollection<Offer> _offers;

        public OfferViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;

            Location = _sessionService.RegisteredLocation;
            Offers = new ObservableCollection<Offer>(Location.Offers);
        }



        // Command Implementation
        [RelayCommand]
        private async Task GoToOfferDetail(Offer selectedOffer)
        {
            if (selectedOffer == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedOffer", selectedOffer }
            };

            await Shell.Current.GoToAsync(nameof(OfferDetailPage), navigationParameter);
        }
    }
}