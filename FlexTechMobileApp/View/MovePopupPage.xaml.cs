using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;

namespace FlexTechMobileApp.View;

public partial class MovePopupPage
{
    MovePopupViewModel ViewModel;
    WarehouseModel Selected;
    ILocalizationResourceManager _loc;
    ProductService ProductService;

	public MovePopupPage(MovePopupViewModel viewModel, ILocalizationResourceManager loc)
	{
		InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
        _loc = loc;
        ProductService = new(loc);
	}

    /* For the pesky user who miss clicked and wanna go back to the popup menu.
     */
    private async void Button_Clicked_Cancel(object sender, EventArgs e)
    {
		await MopupService.Instance.PopAsync();
    }

    /* This method is called when the user presses the save button.
     * Button can not be pressed/will do nothing if no other warehouse is selected
     * It will update the products connection to a warehouse in the database.
     */
    private async void Button_Clicked_Save(object sender, EventArgs e)
    {
        if (Selected == null)
            return;

        try
        {
            bool confirmed = await DisplayAlert(_loc["Confirmation"], _loc["WannaMoveTheProductTo"], _loc["Yes"], _loc["No"]);

            if (IsBusy || !confirmed)
            {
                return;
            }

            IsBusy = true;

            ViewModel.Product.Warehouse_id = Selected.Id;
            await ProductService.MoveProduct(ViewModel.Product);

            await MopupService.Instance.PopAllAsync();

        }
        finally
        {
            IsBusy = false;
        }
    }

    /* This method is called whenever the user selects anything from the picker menu popup
     * When the user selects a warehouse it will be saved to the selected.
     * And no it is not possible to unselect so no warehouse is selected again.
     */
    private void NewWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            Selected = ViewModel.WarehouseList[selectedIndex];
        }
    }
}