using Microsoft.Extensions.Logging;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.ViewModels;
using RetailRewardsApp.Mobile.Views;

namespace RetailRewardsApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ScanViewModel>();
            builder.Services.AddTransient<ScanPage>();
            builder.Services.AddTransient<MenuViewModel>();
            builder.Services.AddTransient<MenuPage>();
            builder.Services.AddTransient<OfferViewModel>();
            builder.Services.AddTransient<OffersPage>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<NotificationDetailViewModel>();
            builder.Services.AddTransient<NotificationDetailPage>();
            builder.Services.AddTransient<TransactionDetailViewModel>();
            builder.Services.AddTransient<TransactionDetailPage>();
            builder.Services.AddTransient<ItemDetailPage>();
            builder.Services.AddTransient<ItemDetailViewModel>();
            builder.Services.AddTransient<OfferDetailPage>();
            builder.Services.AddTransient<OfferDetailViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
