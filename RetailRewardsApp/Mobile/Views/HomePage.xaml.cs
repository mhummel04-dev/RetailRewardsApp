using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();
	}
}