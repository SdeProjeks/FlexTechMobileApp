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
using System.Text.Json;
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

        [ObservableProperty]
        string previus = "";

        [ObservableProperty]
        string next = "";

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

                PaginationProductModelDataModel Page = await productModelService.GetProductModels(search);

                ProductModels.Clear();

                this.Page = Page.Current_page;
                Next = Page.Next_page_url;
                Previus = Page.First_page_url;

                foreach (var productModel in Page.Data)
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

        public async Task SwitchPagesAsync(string url)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                PaginationProductModelDataModel Page = await productModelService.GetPage(url);

                ProductModels.Clear();

                this.Page = Page.Current_page;

                if (Page.Current_page == 1)
                {
                    Previus = Page.Last_page_url;
                } else {
                    Previus = Page.Prev_page_url;
                }

                if (Page.Current_page == Page.Last_page)
                {
                    Next = Page.First_page_url;
                } else
                {
                    Next = Page.Next_page_url;
                }

                List<ProductModel> productModels = Page.Data.Cast<ProductModel>().ToList();

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
