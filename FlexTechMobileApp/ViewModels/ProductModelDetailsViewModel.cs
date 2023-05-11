using CommunityToolkit.Mvvm.ComponentModel;
using FlexTechMobileApp.Models;

namespace FlexTechMobileApp.ViewModels
{
    [QueryProperty(nameof(ProductModel), "ProductModel")]
    public partial class ProductModelDetailsViewModel : BaseViewModel
    {
        public ProductModelDetailsViewModel() {

        }

        [ObservableProperty]
        ProductModel productModel;

        [ObservableProperty]
        int page = 1;
    }
}
