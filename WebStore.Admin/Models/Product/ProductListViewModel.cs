using System.Collections.Generic;
using WebStore.Model;

namespace WebStore.Admin.Models.Product
{
    public class ProductListViewModel
    {
        public List<WebStore.Model.Product> Products { get; set; }

        public List<Section> Sections { get; set; }

        public List<Category> Categories { get; set; }

        public List<Subcategory> Subcategories { get; set; } 
    }
}