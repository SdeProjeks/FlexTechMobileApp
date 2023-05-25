using FlexTechMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Services
{
    public class LoginService: BaseService
    {
        public async Task<string> PostLogin(string email, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAddress}/login?email={email}&password={password}");
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TokenModel token = await response.Content.ReadFromJsonAsync<TokenModel>();
                await SecureStorage.Default.SetAsync("Token", token.Token);
                return token.Token;
            } else {
                await Shell.Current.DisplayAlert("Login Failure", "Username or Password was wrong", "Ok");
                return "Error";
            }
        }
    }
}
