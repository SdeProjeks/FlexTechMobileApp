﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Product_model_id { get; set; }
        public int Status_id { get; set; }
        public int Warehouse_id { get; set; }
        public string Barcode { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
