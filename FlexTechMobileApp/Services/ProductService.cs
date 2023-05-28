using FlexTechMobileApp.Models;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace FlexTechMobileApp.Services
{
    public class ProductService: BaseService
    {
        ILocalizationResourceManager _loc;

        public ProductService(ILocalizationResourceManager loc) { 
            _loc = loc;
        }

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

        public async Task DeleteProduct(Product product)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{BaseAddress}/products/{product.Id}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                await MopupService.Instance.PopAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Could not contact the api", "OK");
            }
        }

        public async Task MoveProduct(Product product)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{BaseAddress}/products/{product.Id}?barcode={product.Barcode}&model={product.Product_model_id}&status=2&warehouse={product.Warehouse_id}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                await MopupService.Instance.PopAllAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Could not contact the api", "OK");
            }
        }

        public async Task<List<WarehouseModel>> GetWarehousesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/warehouses?p=999");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
            var response = await httpClient.SendAsync(request);
            List<WarehouseModel> warehouses = new();

            if (response.IsSuccessStatusCode)
            {
                PaginationWarehouseDTOModel data = await response.Content.ReadFromJsonAsync<PaginationWarehouseDTOModel>();
                warehouses = data.Object.Data;

            } else {
                await Shell.Current.DisplayAlert("Error", "Could not contact the api", "OK");
            }
            
            return warehouses;
        }

        public async Task<Product> GetProduct(string search)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/product/searchProduct?barcode={search}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));

            var response = await httpClient.SendAsync(request);
            Product product = new();

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadFromJsonAsync<Product>();
            }

            return product;
        }
    }
}
