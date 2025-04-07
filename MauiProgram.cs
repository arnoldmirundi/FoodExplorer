using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using FoodExplorer.Database;
using FoodExplorer.Services;
using FoodExplorer.Views;

namespace FoodExplorer
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

            builder.Services.AddSingleton<FoodDatabase>();
            builder.Services.AddSingleton<FoodService>();
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<DeviceService>();
            builder.Services.AddSingleton<TextToSpeechService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ContinentPage>();
            builder.Services.AddTransient<FoodDetailPage>();
            builder.Services.AddTransient<RecipePage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
