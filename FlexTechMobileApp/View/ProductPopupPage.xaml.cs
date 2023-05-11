using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;
using System.Reflection.Emit;

namespace FlexTechMobileApp.View;

public partial class ProductPopupPage
{
    private ProductPopupViewModel ViewModel;

	public ProductPopupPage(ProductPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        ViewModel = viewModel;
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
            if (IsBusy)
                return;

            IsBusy = true;
            // API call to extract/change the category of the product
            await DisplayAlert("Call API", "API called", "OK");

            await MopupService.Instance.PopAsync();
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

            IsBusy = true;
            List<Warehouse> warehouses = new()
            {
                new (){ Id = 1, Name = "test"},
                new (){ Id = 2, Name = "test2"}
            };

            MovePopupViewModel movePopupViewModel = new(ViewModel.Product, warehouses);

            
            await MopupService.Instance.PushAsync(new MovePopupPage(movePopupViewModel));
        }
        finally
        {
            IsBusy = false;
        }
    }
}