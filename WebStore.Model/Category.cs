using System.Collections.Generic;

namespace WebStore.Model
{
    public class Category
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public int SectionId { get; set; }
        public List<Subcategory> SubCategories { get; set; }
    }
}