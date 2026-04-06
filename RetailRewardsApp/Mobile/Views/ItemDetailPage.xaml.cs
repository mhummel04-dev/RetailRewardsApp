using RetailRewardsApp.Mobile.ViewModels;
namespace RetailRewardsApp.Mobile.Views;

public partial class ItemDetailPage : ContentPage
{
	public ItemDetailPage(ItemDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}