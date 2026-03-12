using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class OffersPage : ContentPage
{
	public OffersPage()
	{
		InitializeComponent();
		BindingContext = new OfferViewModel();
	}
}