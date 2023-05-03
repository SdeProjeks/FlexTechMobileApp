using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(LoginViewModel loginViewModel)
	{
        InitializeComponent();
		BindingContext = loginViewModel;
	}
}

