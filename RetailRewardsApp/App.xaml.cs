using Microsoft.Extensions.DependencyInjection;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}