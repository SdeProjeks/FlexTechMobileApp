using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int Postal_code_id { get; set; }
        public string Address { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public PostalCodeModel Postal_code { get; set; }
    }
}
