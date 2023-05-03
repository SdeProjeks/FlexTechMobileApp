using FlexTechMobileApp.View;
using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<MenuPage>();
		builder.Services.AddSingleton<MenuViewModel>();
		builder.Services.AddSingleton<ProductModelsPage>();
		builder.Services.AddTransient<ProductModelsViewModel>();
		builder.Services.AddTransient<ProductModelDetailsViewModel>();

		return builder.Build();
	}
}
