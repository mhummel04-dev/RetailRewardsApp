using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedNotification), "SelectedNotification")]
    public partial class NotificationDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private Notification _selectedNotification;

    }
}
