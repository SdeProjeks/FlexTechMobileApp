using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp.View;

public partial class ProductModelsPage : ContentPage
{
    ProductModelsViewModel viewModel;
	public ProductModelsPage(ProductModelsViewModel productModelsViewModel)
	{
		InitializeComponent();
		BindingContext = productModelsViewModel;
        viewModel = productModelsViewModel;
        GetProductModels();
    }

    private async void GetProductModels()
    {
        await viewModel.GetProductModelsAsync(SearchBar.Text);
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        await viewModel.GetProductModelsAsync(SearchBar.Text);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProductModelDetailsPage),true);
    }
}