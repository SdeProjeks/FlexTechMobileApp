using FlexTechMobileApp.View;

namespace FlexTechMobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
		Routing.RegisterRoute(nameof(ProductModelsPage), typeof(ProductModelsPage));
		Routing.RegisterRoute(nameof(BarcodeReaderPage), typeof(BarcodeReaderPage));
		Routing.RegisterRoute(nameof(ProductModelDetailsPage), typeof(ProductModelDetailsPage));
	}
}
