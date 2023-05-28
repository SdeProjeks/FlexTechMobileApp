using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;

namespace FlexTechMobileApp.View;

public partial class ProductModelDetailsPage : ContentPage
{
	ILocalizationResourceManager _loc;
	ProductModelDetailsViewModel ViewModel;

    public ProductModelDetailsPage(ProductModelDetailsViewModel viewmodel, ILocalizationResourceManager loc)
	{
		InitializeComponent();
		BindingContext = viewmodel;
		ViewModel = viewmodel;
		_loc = loc;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (IsBusy)
				return;

            IsBusy = true;
            var product = ((VisualElement)sender).BindingContext as Product;

            if (product == null)
                return;

            ProductPopupViewModel viewModel = new(product, _loc);

            await MopupService.Instance.PushAsync(new ProductPopupPage(viewModel, _loc, ViewModel));
        }
		finally
		{
			IsBusy = false;
		}
    }
}