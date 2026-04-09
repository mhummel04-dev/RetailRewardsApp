using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace RetailRewardsApp.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedTransaction), "SelectedTransaction")]
    public partial class TransactionDetailViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private Transaction _selectedTransaction;
        [ObservableProperty]
        private ObservableCollection<TransactionItem> _itemsPurchased;
        [ObservableProperty]
        private ObservableCollection<Offer> _offersUsed;
        
        public TransactionDetailViewModel(SessionService sessionService) 
        {
            _sessionService = sessionService;
        }

        partial void OnSelectedTransactionChanged(Transaction value)
        {
            ItemsPurchased = new ObservableCollection<TransactionItem>(value.ItemsPurchased);
            OffersUsed = new ObservableCollection<Offer>(value.OffersUsed);
        }


        //Command Implementation
        [RelayCommand]
        private async Task GoToItemDetail(Guid itemId)
        {
            if (itemId == Guid.Empty) return;

            var item = _sessionService.FakeDB.FakeItemTable.FirstOrDefault(x => x.Id == itemId);
            var navParam = new Dictionary<string, object> { { "SelectedItem", item } };

            await Shell.Current.GoToAsync(nameof(ItemDetailPage), navParam);
            
        }

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
