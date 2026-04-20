using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Interfaces;
using System.Text.Json;
using RetailRewardsApp.Mobile.Converters;
using System.Text.Json.Serialization;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private User _user;
        [ObservableProperty]
        private ObservableCollection<Notification> _notifications;
        [ObservableProperty]
        private ObservableCollection<Transaction> _purchaseHistory;

        //XAML var(s)
        [ObservableProperty]
        private ObservableCollection<Item> _recommendedItems;
        [ObservableProperty]
        private ObservableCollection<Offer> _recommendedOffers;



        private readonly IAIService _aiService;

        public HomeViewModel(SessionService sessionService, IAIService aiService) 
        {
            _sessionService = sessionService;
            _user = _sessionService.LoggedInUser;
            _notifications = new ObservableCollection<Notification>(_user.Notifications);
            _purchaseHistory = new ObservableCollection<Transaction>(_user.Transactions);
            _aiService = aiService;

            Task.Run(async () => await RefreshRecommendations());
        }


        // Command Implementation
        [RelayCommand]
        private async Task GoToNotification(Notification selectedNotification)
        {
            if (selectedNotification == null) { return; }

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedNotification", selectedNotification }
            };

            await Shell.Current.GoToAsync(nameof(NotificationDetailPage), navigationParameter);
        }

        [RelayCommand]
        private async Task GoToTransaction(Transaction selectedTransaction)
        {
            if (selectedTransaction == null) { return; }

            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedTransaction", selectedTransaction }
            };

            await Shell.Current.GoToAsync(nameof(TransactionDetailPage), navigationParameter);
        }

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

        [RelayCommand]
        public async Task RefreshRecommendations()
        {
            string prompt = @"
                [PROCESS]
                    1. Call 'get_recent_purchases' to understand the user's taste.
                    2. Call 'get_available_items' and 'get_available_offers' to see IDs of what's in stock.
                    3. Pick the best matches.
                    4. FOR EACH picked item/offer, call 'get_item_by_id' or 'get_offer_by_id' to get the full, valid object.
                    
                    [OUTPUT]
                    Return ONLY raw JSON matching this structure. The 'Items' and 'Offers' arrays must contain the FULL objects returned by your tools.
                    EXCEPT, EXCLUDE the lists of Items that are associated inside of Offers, and Offers associated inside of Items. Simply dont report this data for now.
                    {
                      ""Items"": [ { /* Full Item Object */ } ],
                      ""Offers"": [ { /* Full Offer Object */ } ]
                    }
                    IMPORTANT: When returning the JSON, if there is an object cycle occurring, simply quit the cycle and only focus on the top level object.
                    Follow this rule after 2 cycles (I.E Offer.Item.Offer.Item (Offer.Item = 1, Offer.Item = 2))
                    ";

            var rawResponse = await _aiService.GetResponseAsync(prompt);

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.IgnoreCycles };
                var data = JsonSerializer.Deserialize<RecommendationResult>(rawResponse, options);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    RecommendedItems = new ObservableCollection<Item>(data.Items);
                    RecommendedOffers = new ObservableCollection<Offer>(data.Offers);
                });
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"AI sent bad JSON: {rawResponse}");
            }
        }
    }
}
