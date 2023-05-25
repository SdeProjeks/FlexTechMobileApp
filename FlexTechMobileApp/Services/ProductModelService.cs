using FlexTechMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Services
{
    public class ProductModelService: BaseService
    {
        public async Task<PaginationProductModelDataModel> GetProductModels(string search = "")
        {
            PaginationProductModelDataModel products = new();
            bool SuccessApiCall = false;

            while (!SuccessApiCall)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/models?p={PageAmount}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    PaginationProductModelModel page = await response.Content.ReadFromJsonAsync<PaginationProductModelModel>();

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

        public async Task<PaginationProductModelDataModel> GetPage(string url = "")
        {
            PaginationProductModelDataModel products = new();
            bool SuccessApiCall = false;

            while (!SuccessApiCall)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync("Token"));
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    PaginationProductModelModel page = await response.Content.ReadFromJsonAsync<PaginationProductModelModel>();

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
    }
}
