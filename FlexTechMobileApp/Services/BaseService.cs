using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Services
{
    public class BaseService
    {
        public HttpClient httpClient = new();
        public string BaseAddress = "http://192.168.0.64:8080/api";
        public int PageAmount = 15;

        public bool IsBusy = false;


    }
}
