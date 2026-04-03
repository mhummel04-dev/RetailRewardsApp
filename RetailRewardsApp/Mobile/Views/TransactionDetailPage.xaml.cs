using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class TransactionDetailPage : ContentPage
{
	public TransactionDetailPage(TransactionDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}