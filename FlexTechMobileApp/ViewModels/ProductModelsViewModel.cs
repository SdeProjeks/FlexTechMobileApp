using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.ViewModels
{
    public partial class ProductModelsViewModel : BaseViewModel
    {
        /* ObservableCollection has an inotify inside of it.
         * So whenevner you remove or add anything the data will update on the view
         */
        public ObservableCollection<ProductModel> ProductModels { get; } = new();

        ProductModelService productModelService;

        [ObservableProperty]
        string search = "";

        [ObservableProperty]
        int page = 1;

        public ProductModelsViewModel(ProductModelService productModelService) {
            Title = "Product models list";
            this.productModelService = productModelService;
        }

        [RelayCommand]
        async Task GoToBarcodePage()
        {
            await Shell.Current.GoToAsync(nameof(BarcodeReaderPage),true);
        }


        public async Task GetProductModelsAsync(string search)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var productModels = await productModelService.GetProductModels(search);

                ProductModels.Clear();

                foreach (var productModel in productModels)
                {
                    ProductModels.Add(productModel);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }

    }
}
