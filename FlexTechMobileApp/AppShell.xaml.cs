using FlexTechMobileApp.View;

namespace FlexTechMobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
	}
}
