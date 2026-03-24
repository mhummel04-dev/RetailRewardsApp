using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class OffersPage : ContentPage
{
	public OffersPage(OfferViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}