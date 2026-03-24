using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}