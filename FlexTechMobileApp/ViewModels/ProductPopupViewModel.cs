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

namespace FlexTechMobileApp.ViewModels
{
    public partial class ProductPopupViewModel : BaseViewModel
    {
        [ObservableProperty]
        Product product;

        public ProductPopupViewModel(Product viewModel) { 
            product = viewModel;
        }

        [RelayCommand]
        public async Task GoToMovePopup()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


            string text = "This is a Toast";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
