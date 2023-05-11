using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;

namespace FlexTechMobileApp.View;

public partial class ProductModelDetailsPage : ContentPage
{
	ILocalizationResourceManager _localizationResourceManager;

	public ProductModelDetailsPage(ProductModelDetailsViewModel viewmodel, ILocalizationResourceManager localizationResourceManager)
	{
		InitializeComponent();
		BindingContext = viewmodel;

		_localizationResourceManager = localizationResourceManager;
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

            ProductPopupViewModel viewModel = new(product);

            await MopupService.Instance.PushAsync(new ProductPopupPage(viewModel, _localizationResourceManager));
        }
		finally
		{
			IsBusy = false;
		}
    }
}