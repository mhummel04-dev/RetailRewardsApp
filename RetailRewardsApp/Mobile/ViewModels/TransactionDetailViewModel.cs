using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using RetailRewardsApp.Core.Models;
using System.Collections.ObjectModel;


namespace RetailRewardsApp.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedTransaction), "SelectedTransaction")]
    public partial class TransactionDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private Transaction _selectedTransaction;
        [ObservableProperty]
        private ObservableCollection<TransactionItem> _itemsPurchased;
        [ObservableProperty]
        private ObservableCollection<Offer> _offersUsed;
        
        public TransactionDetailViewModel() {}

        partial void OnSelectedTransactionChanged(Transaction value)
        {
            ItemsPurchased = new ObservableCollection<TransactionItem>(value.ItemsPurchased);
            OffersUsed = new ObservableCollection<Offer>(value.OffersUsed);
        }

    }
}
