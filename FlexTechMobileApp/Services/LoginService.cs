using FlexTechMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Services
{
    public class LoginService
    {
        HttpClient httpClient;
        public LoginService() { 
            httpClient = new();
        }

        //public async<Task<User>> PostLogin(string email, string password)
        //{
        //    User user = new();

        //    return user;
        //}
    }
}
