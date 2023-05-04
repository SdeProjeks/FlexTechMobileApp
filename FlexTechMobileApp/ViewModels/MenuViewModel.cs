using CommunityToolkit.Mvvm.Input;
using FlexTechMobileApp.View;

namespace FlexTechMobileApp.ViewModels
{
    public partial class MenuViewModel : BaseViewModel
    {
        public MenuViewModel() { 
            Title = "Menu";
        }

        [RelayCommand]
        async Task Logout()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                SecureStorage.Default.Remove("oAuth");

                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        async Task LagerSystem()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync(nameof(ProductModelsPage), true);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        async Task AnnualCensus()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync(nameof(ProductModelsPage), true);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }
    }
}
