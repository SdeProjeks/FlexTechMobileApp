using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string oAuth { get; set; }
        public string phone_number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
