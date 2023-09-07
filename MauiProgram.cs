using Microsoft.Extensions.Logging;

namespace SearchBarTintColorTest;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("AppearanceHandler", (handler, view) =>
        {
#if IOS    
            handler.PlatformView.SearchBarStyle = UIKit.UISearchBarStyle.Minimal;
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.BarTintColor = UIKit.UIColor.Clear;
#endif
        });
        return builder.Build();
	}
}
