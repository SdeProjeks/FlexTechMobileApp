using CommunityToolkit.Mvvm.ComponentModel;
using FlexTechMobileApp.Models;
using LocalizationResourceManager.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.ViewModels
{
    public partial class MovePopupViewModel : BaseViewModel
    {
        [ObservableProperty]
        Product product;

        [ObservableProperty]
        List<Warehouse> warehouseList;

        public MovePopupViewModel(Product product, List<Warehouse> warehouses) { 
            warehouseList = warehouses;
            this.product = product;
        }
    }
}
