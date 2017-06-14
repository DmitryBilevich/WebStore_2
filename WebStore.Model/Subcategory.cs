using System.Collections.Generic;

namespace WebStore.Model
{
    public class Subcategory
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}