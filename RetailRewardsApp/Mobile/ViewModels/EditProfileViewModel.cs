using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RetailRewardsApp.Core.Models;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using System.Collections.ObjectModel;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class EditProfileViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private User _user;

        // XAML variable(s)
        [ObservableProperty]
        private string _firstName, _lastName, _email, _password, _phoneNumber, _birthday;



        public EditProfileViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;

            User = _sessionService.LoggedInUser;

            FirstName = User.FirstName;
            LastName = User.LastName;
            Email = User.EmailAddress;
            Password = User.Password;
            PhoneNumber = User.PhoneNumber;
            Birthday = User.Birthday.ToString("MM/dd/yyyy");
        }



        // Command Implementation
        [RelayCommand]
        private async Task SaveEdits()
        {
            User changedUser = User;
            changedUser.FirstName = FirstName;
            changedUser.LastName = LastName;
            changedUser.EmailAddress = Email;
            changedUser.Password = Password;
            changedUser.PhoneNumber = PhoneNumber;
            changedUser.Birthday = DateTime.Parse(Birthday);

            _sessionService.EditUser(changedUser);
            var index = _sessionService.FakeDB.FakeUserTable.IndexOf(User);
            _sessionService.FakeDB.FakeUserTable[index] = changedUser;

            if (_sessionService.FakeDB.FakeUserTable.Contains(_sessionService.LoggedInUser))
            {
                await Shell.Current.GoToAsync(nameof(ProfilePage));
            }
        }
    }
}