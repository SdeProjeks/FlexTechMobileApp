using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp;

public partial class MainPage : ContentPage
{
	public MainPage(LoginViewModel loginViewModel)
	{
        InitializeComponent();
		BindingContext = loginViewModel;
	}
}

