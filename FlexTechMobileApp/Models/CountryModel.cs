using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Postal_code { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
