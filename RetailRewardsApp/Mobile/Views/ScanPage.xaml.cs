using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;


public partial class ScanPage : ContentPage
{
	public ScanPage(ScanViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}