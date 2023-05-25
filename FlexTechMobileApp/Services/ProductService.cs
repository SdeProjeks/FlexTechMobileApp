using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using Mopups.Services;
using System.Net.Http.Headers;

namespace FlexTechMobileApp.Services
{
    public class ProductService: BaseService
    {
        public async Task DeleteProduct(Product product, ProductModelDetailsViewModel viewModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{BaseAddress}/products/{product.Id}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                viewModel.ProductModel.Products.Remove(product);
                await MopupService.Instance.PopAsync();
            } else
            {
                await Shell.Current.DisplayAlert("Error", "Could not contact the api", "OK");
            }
        }
    }
}
