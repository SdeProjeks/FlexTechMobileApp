using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public int Address_id { get; set; }
        public int Status_id { get; set; }
        public string Name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public AddressModel Address { get; set; }

    }
}
