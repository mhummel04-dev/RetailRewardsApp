using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            GoToAsync("//login");

            Routing.RegisterRoute(nameof(NotificationDetailPage), typeof(NotificationDetailPage));
            Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(OfferDetailPage), typeof(OfferDetailPage));
            Routing.RegisterRoute(nameof(TransactionDetailPage), typeof(TransactionDetailPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

        }
    }
}
