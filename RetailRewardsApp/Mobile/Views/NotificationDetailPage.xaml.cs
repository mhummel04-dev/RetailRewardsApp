using RetailRewardsApp.Mobile.ViewModels;

namespace RetailRewardsApp.Mobile.Views;

public partial class NotificationDetailPage : ContentPage
{
	public NotificationDetailPage(NotificationDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}