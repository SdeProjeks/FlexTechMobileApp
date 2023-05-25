using System.Collections.ObjectModel;

namespace FlexTechMobileApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Status_id { get; set; }
        public int Count_status_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public float Price { get; set; }
        public string Dimensions { get => "W: "+Width+" L: "+Length+" H: "+Height; }
        public int Weight { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public CountStatusModel Count_status { get; set; }
        public StatusModel Status { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new();
    }
}
