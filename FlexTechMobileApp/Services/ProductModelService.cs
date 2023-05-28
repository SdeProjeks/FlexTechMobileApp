using FlexTechMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LocalizationResourceManager.Maui;

namespace FlexTechMobileApp.Services
{
    public class ProductModelService: BaseService
    {
        ILocalizationResourceManager _loc;

        public ProductModelService(ILocalizationResourceManager loc) { 
            _loc = loc;
        }

        public async Task<PaginationProductModelDTO> GetProductModels(string search = "")
        {
            PaginationProductModelDTO products = new();
            bool SuccessApiCall = false;

            while (!SuccessApiCall)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/models?p={PageAmount}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    PaginationProductModelDTOModel page = await response.Content.ReadFromJsonAsync<PaginationProductModelDTOModel>();

                    products = page.Object;

                    SuccessApiCall = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Could not contact the API press OK to try again", "OK");
                }
            }
            
            return products;
        }

        public async Task<PaginationProductModelDTO> GetPage(string url = "")
        {
            PaginationProductModelDTO products = new();
            bool SuccessApiCall = false;

            while (!SuccessApiCall)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    PaginationProductModelDTOModel page = await response.Content.ReadFromJsonAsync<PaginationProductModelDTOModel>();

                    products = page.Object;

                    SuccessApiCall = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Could not contact the API press OK to try again", "OK");
                }
            }

            return products;
        }

        public async Task<ProductModel> GetProductModel(string search)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/model/searchModel?barcode={search}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));

            var response = await httpClient.SendAsync(request);
            ProductModel product = new();

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadFromJsonAsync<ProductModel>();
            }

            return product;
        }
    }
}
