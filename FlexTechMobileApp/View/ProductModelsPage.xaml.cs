using FlexTechMobileApp.ViewModels;

namespace FlexTechMobileApp.View;

public partial class ProductModelsPage : ContentPage
{
	public ProductModelsPage(ProductModelsViewModel productModelsViewModel)
	{
		InitializeComponent();
		BindingContext = productModelsViewModel;
    }
}