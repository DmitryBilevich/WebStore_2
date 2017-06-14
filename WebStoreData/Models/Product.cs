using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
    public class Product
    {
        public Product()
        {
            ProductDescriptions = new List<ProductDescription>();
            ProductPictures = new List<ProductPicture>();
        }
        public virtual ICollection<ProductDescription> ProductDescriptions { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int? SectionId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        //public List<ProductDescription> ShortDiscriptions { get; set; }
        //public List<string> Pictures { get; set; }
        //public List<ProductDescription> Descriptions { get; set; }
    }
}
