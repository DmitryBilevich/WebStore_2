using System.Collections.Generic;

namespace WebStore.Model
{
    public class Product
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public int ProductId { get; set; }
        public int SectionId { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public List<string> ShortDescriptions { get; set; }
        public List<string> Pictures { get; set; }
        public List<ProductDescription> Descriptions { get; set; }
    }
}