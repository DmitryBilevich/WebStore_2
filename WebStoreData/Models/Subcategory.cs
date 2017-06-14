using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
   public class Subcategory
    {
       public Subcategory()
        {
            Products = new List<Product>();
        }
        public virtual ICollection<Product> Products { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public virtual Category Category { get; set; }
        //public List<Product> Products { get; set; }
    }
}
