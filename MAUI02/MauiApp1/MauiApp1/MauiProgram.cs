using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        // 사용하는 플랫폼(ANDROID, IOS, WINDOWS, MAC 등)에 따른 APP BUILD 방식 선언
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
