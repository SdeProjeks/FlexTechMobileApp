using Camera.MAUI;
using CommunityToolkit.Maui;
using FlexTechMobileApp.Resources.Translations;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.View;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Hosting;

namespace FlexTechMobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureMopups()
			.UseLocalizationResourceManager(settings =>
			{
				settings.RestoreLatestCulture(true);
				settings.AddResource(AppResource.ResourceManager);
			})
			.UseMauiCameraView()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<ProductModelService>();
		builder.Services.AddSingleton<MenuPage>();
		builder.Services.AddSingleton<MenuViewModel>();
		builder.Services.AddSingleton<BarcodeReaderPage>();
		builder.Services.AddTransient<ProductModelsPage>();
		builder.Services.AddTransient<ProductModelsViewModel>();
		builder.Services.AddTransient<ProductModelDetailsPage>();
		builder.Services.AddTransient<ProductModelDetailsViewModel>();

		return builder.Build();
	}
}
