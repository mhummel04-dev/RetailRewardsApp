using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

    }
}
