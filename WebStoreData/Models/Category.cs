using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
   public class Category
    {
       public Category()
        {
            Subcategories = new List<Subcategory>();
        }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        //public List<Subcategory> SubCategories { get; set; }
    }
}
