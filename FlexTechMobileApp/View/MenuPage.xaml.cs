using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp.View;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel menuViewModel)
	{
		InitializeComponent();
		BindingContext = menuViewModel;
	}
}