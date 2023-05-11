using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public string Dimensions { get => "W: "+Width+" L: "+Length+" H: "+Height; }
        public int Weight { get; set; }
        public float Price { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
