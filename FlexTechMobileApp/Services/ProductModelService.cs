using FlexTechMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Services
{
    public class ProductModelService
    {
        HttpClient httpClient = new();

        public async Task<List<ProductModel>> GetProductModels(string search = "")
        {
            List<ProductModel> products = new();
            ProductModel model = new();
            model.Id = 1; model.Name = "test"; model.Width = 17; model.Height = 20; model.Length = 18; model.Weight = 17;

            products.Add(model);

            ProductModel model2 = new();
            model2.Id = 2; model2.Name = "test2"; model2.Width = 2; model2.Height = 7; model2.Length = 8; model2.Weight = 16;
            products.Add(model2);

            await Shell.Current.DisplayAlert("SUCCES", "Call to api", "OK");

            return products;
        }
    }
}
