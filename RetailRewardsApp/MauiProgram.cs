using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Services;
using RetailRewardsApp.Core.Interfaces;
using RetailRewardsApp.Core.Plugins;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.ViewModels;
using RetailRewardsApp.Mobile.Views;
using System.Reflection;

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
            builder.Services.AddTransient<EditProfileViewModel>();
            builder.Services.AddTransient<EditProfilePage>();
            builder.Services.AddTransient<UserHistoryPlugin>();
            builder.Services.AddTransient<CatalogPlugin>();


            //AI Stuff
            builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<Core.Interfaces.IAIService, GeminiService>();

            var kernelBuilder = Kernel.CreateBuilder();
            var apiKey = builder.Configuration["Gemini:ApiKey"];

            builder.Services.AddTransient<Kernel>((serviceProvider) =>
            {
                var kernelBuilder = Kernel.CreateBuilder();

                kernelBuilder.AddGoogleAIGeminiChatCompletion(
                    modelId: "gemini-3.1-flash-lite-preview",
                    apiKey: apiKey);

                var historyPlugin = serviceProvider.GetRequiredService<UserHistoryPlugin>();
                var catalogPlugin = serviceProvider.GetRequiredService<CatalogPlugin>();

                kernelBuilder.Plugins.AddFromObject(historyPlugin);
                kernelBuilder.Plugins.AddFromObject(catalogPlugin);

                return kernelBuilder.Build();
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
