using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}