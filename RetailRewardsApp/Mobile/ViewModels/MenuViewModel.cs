using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private Core.Models.Location _currentLocation;
        [ObservableProperty]
        private ObservableCollection<Item> _menuItems;



        public MenuViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;
            
            CurrentLocation = _sessionService.RegisteredLocation;

            MenuItems = new ObservableCollection<Item>(CurrentLocation.Inventory);
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

        [RelayCommand]
        private async Task ChangeLocation()
        {
            await Task.CompletedTask;
        }
    }
}