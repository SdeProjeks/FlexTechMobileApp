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
        public string BaseAddress = "http://10.130.66.50:8080/api";
        public int PageAmount = 15;


    }
}
