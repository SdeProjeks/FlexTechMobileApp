using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlexTechMobileApp.Models;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using FlexTechMobileApp.Services;
using LocalizationResourceManager.Maui;
using Mopups.Services;
using FlexTechMobileApp.View;

namespace FlexTechMobileApp.ViewModels
{
    public partial class ProductPopupViewModel : BaseViewModel
    {
        [ObservableProperty]
        Product product;

        ILocalizationResourceManager _loc;
        ProductService productService;

        public ProductPopupViewModel(Product viewModel, ILocalizationResourceManager loc) { 
            Product = viewModel;
            _loc = loc;
            productService = new(loc);
        }

        [RelayCommand]
        public async Task GoToMovePopup()
        {
            IsBusy = true;
            List<WarehouseModel> warehouses = await productService.GetWarehousesAsync();

            WarehouseModel warehouse = warehouses.Find(x => x.Id == Product.Warehouse_id);
            //warehouses.RemoveAll(x => x.Id.Equals(Product.Warehouse));

            MovePopupViewModel movePopupViewModel = new(product, warehouse, warehouses);


            await MopupService.Instance.PushAsync(new MovePopupPage(movePopupViewModel, _loc));
        }

        public async Task Extract(ProductModelDetailsViewModel viewModel)
        {
            await productService.DeleteProduct(product, viewModel);
        }

        public async Task Extract()
        {
            await productService.DeleteProduct(product);
        }
    }
}
