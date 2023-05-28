using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;
using System.Reflection.Emit;

namespace FlexTechMobileApp.View;

public partial class ProductPopupPage
{
    private ProductPopupViewModel ViewModel;
    ILocalizationResourceManager _loc;
    ProductModelDetailsViewModel _productModelDetailsViewModel;
    public bool fromBarcode = false;

    public ProductPopupPage(ProductPopupViewModel viewModel, ILocalizationResourceManager loc)
    {
        InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
        _loc = loc;
        _productModelDetailsViewModel = new();
        fromBarcode = true;
    }

    public ProductPopupPage(ProductPopupViewModel viewModel, ILocalizationResourceManager loc, ProductModelDetailsViewModel productModelDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        ViewModel = viewModel;
        _loc = loc;
        _productModelDetailsViewModel = productModelDetailsViewModel;
	}

    // Closes the popup did you expect anything else ?_?
    private async void Button_Clicked_Close(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }

    /* This method will extract the product of the productmodel from the database.
     * Which will mean that the product is being moved out from storage and to the customer.
     */
    private async void Button_Clicked_Extract(object sender, EventArgs e)
    {
        try
        {
            bool confirmed = await DisplayAlert(_loc["Confirmation"], _loc["SureYouWannaExtract"], _loc["Yes"], _loc["No"]);

            if (IsBusy || !confirmed)
                return;

            IsBusy = true;
            if (fromBarcode)
            {
                await ViewModel.Extract();
                return;
            } else {
                await ViewModel.Extract(_productModelDetailsViewModel);
                return;
            }


        }
        finally
        {
            IsBusy = false;
        }
    }

    /* This method redirects the user to the move product popup menu.
     * The method will first get all the warehouses and move that
     * to the move page for the dropdown.
     */
    private async void Button_Clicked_Move(object sender, EventArgs e)
    {
        try
        {
            if (IsBusy)
                return;

            await ViewModel.GoToMovePopup();
        }
        finally
        {
            IsBusy = false;
        }
    }
}