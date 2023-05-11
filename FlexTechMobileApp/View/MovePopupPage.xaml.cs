using CommunityToolkit.Maui.Views;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;

namespace FlexTechMobileApp.View;

public partial class MovePopupPage
{
    MovePopupViewModel ViewModel;
    Warehouse Selected;

	public MovePopupPage(MovePopupViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
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
            if (IsBusy)
                return;

            // API CALL FOR UPDATE
            await Shell.Current.DisplayAlert("API CALL", Selected.Name, "OK");

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