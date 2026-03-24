using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        // Service(s) and associated var(s)
        private readonly SessionService SessionService;
        private Core.Models.Location Location;
        private ObservableCollection<Item> _menu;


        // Command Declarations
        public ICommand GoToItemDetailCommand { get; }


        // Binding Variables
        public ObservableCollection<Item> BindingMenu { get =>  _menu; set
            {
                if (_menu != value)
                {
                    _menu = value;
                    OnPropertyChanged();
                }
            } 
        }

        public MenuViewModel(SessionService sessionService) 
        {
            SessionService = sessionService;
            Location = SessionService.RegisteredLocation;
            BindingMenu = new ObservableCollection<Item>(Location.Inventory);


            GoToItemDetailCommand = new Command(async () => await GoToItemDetail());
        }

        private async Task GoToItemDetail()
        {
            await Shell.Current.GoToAsync(nameof(ItemDetailPage));
        }


        // INotifyPropertyChanged invoker
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
