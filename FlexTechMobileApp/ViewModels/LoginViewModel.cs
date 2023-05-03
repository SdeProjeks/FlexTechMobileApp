using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlexTechMobileApp.Models;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public String email;

        [ObservableProperty]
        public String password;

        public LoginViewModel()
        {
            Title = "Login";
        }

        [RelayCommand]
        async Task PostLoginAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                //User user = await loginService.PostLogin();

                // Sets session
                await SecureStorage.Default.SetAsync("oAuth", "I am session");

                await Shell.Current.GoToAsync(nameof(MenuPage), true);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }
    }
}
