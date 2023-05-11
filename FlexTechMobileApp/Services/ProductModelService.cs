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
            model.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur mollis rutrum mi, non viverra orci molestie eu. Fusce non ultrices lectus. Ut tincidunt massa non augue suscipit posuere. Donec commodo, dui eget venenatis elementum, odio justo lacinia mauris, commodo accumsan est metus in nisi. Duis nec erat efficitur, ornare leo volutpat, gravida diam. Fusce in libero nibh. Praesent vel justo ligula.\r\n\r\nQuisque aliquet orci sit amet risus varius, a viverra augue rutrum. Phasellus semper ut urna a pulvinar. Mauris nec tempus nulla, a pretium quam. Aliquam eros nisl, dignissim sed elit sed, dapibus pharetra dui. Phasellus vulputate erat id urna venenatis, sollicitudin scelerisque lectus consectetur. Ut ut scelerisque erat, vel facilisis sem. Donec convallis, dolor quis dapibus cursus, tortor ante consectetur felis, non auctor eros nulla non mauris. In quam nibh, vestibulum sollicitudin posuere eu, porttitor sit amet sem. Ut tempor, nulla vitae pretium sodales, nulla nunc interdum diam, vel vestibulum nunc tellus eu mi. Pellentesque euismod risus condimentum lacus suscipit, non ullamcorper leo tincidunt. Phasellus fermentum fringilla ex posuere scelerisque.";

            for (int i = 0; i < 10; i++)
            {
                model.Products.Add(new() { Id = i, Barcode = "E11B56" });
            }

            products.Add(model);

            ProductModel model2 = new();
            model2.Id = 2; model2.Name = "test2"; model2.Width = 2; model2.Height = 7; model2.Length = 8; model2.Weight = 16;
            model2.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur mollis rutrum mi, non viverra orci molestie eu. Fusce non ultrices lectus. Ut tincidunt massa non augue suscipit posuere. Donec commodo, dui eget venenatis elementum, odio justo lacinia mauris, commodo accumsan est metus in nisi. Duis nec erat efficitur, ornare leo volutpat, gravida diam. Fusce in libero nibh. Praesent vel justo ligula.\r\n\r\nQuisque aliquet orci sit amet risus varius, a viverra augue rutrum. Phasellus semper ut urna a pulvinar. Mauris nec tempus nulla, a pretium quam. Aliquam eros nisl, dignissim sed elit sed, dapibus pharetra dui. Phasellus vulputate erat id urna venenatis, sollicitudin scelerisque lectus consectetur. Ut ut scelerisque erat, vel facilisis sem. Donec convallis, dolor quis dapibus cursus, tortor ante consectetur felis, non auctor eros nulla non mauris. In quam nibh, vestibulum sollicitudin posuere eu, porttitor sit amet sem. Ut tempor, nulla vitae pretium sodales, nulla nunc interdum diam, vel vestibulum nunc tellus eu mi. Pellentesque euismod risus condimentum lacus suscipit, non ullamcorper leo tincidunt. Phasellus fermentum fringilla ex posuere scelerisque.";

            for (int i = 0; i < 10; i++)
            {
                model2.Products.Add(new() { Id = i, Barcode = "MARIOOOOoooooo!!!!!!" });
            }
            products.Add(model2);

            await Shell.Current.DisplayAlert("SUCCES", "Call to api", "OK");

            return products;
        }
    }
}
