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
        }
    }
}
