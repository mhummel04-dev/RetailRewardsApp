using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace RetailRewardsApp.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedOffer), "SelectedOffer")]
    public partial class OfferDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private Offer _selectedOffer;
        [ObservableProperty]
        private ObservableCollection<Item> _items;
        
        public OfferDetailViewModel() {}

        partial void OnSelectedOfferChanged(Offer value)
        {
            Items = new ObservableCollection<Item>(value.Items);
        }

        // Command Implementation
        [RelayCommand]
        private async Task GoToItemDetail(Item selectedItem)
        {
            if (selectedItem == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedItem", selectedItem }
            };

            await Shell.Current.GoToAsync(nameof(ItemDetailPage), navigationParameter);
        }
    }
}
