using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using RetailRewardsApp.Core.Models;
using System.Collections.ObjectModel;


namespace RetailRewardsApp.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedItem), "SelectedItem")]
    public partial class ItemDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private Item _selectedItem;
        [ObservableProperty]
        private ObservableCollection<Offer> _offers;
        
        public ItemDetailViewModel() {}

        partial void OnSelectedItemChanged(Item value)
        {
            Offers = new ObservableCollection<Offer>(value.Offers);
        }
    }
}
