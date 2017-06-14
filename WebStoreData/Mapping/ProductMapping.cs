using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using WebStoreData.Models;


namespace WebStoreData.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasKey(i => new { i.ProductId });

            Property(i => i.ProductId).HasColumnName("ProductId");
            Property(i => i.SectionId).HasColumnName("SectionId");
            Property(i => i.CategoryId).HasColumnName("CategoryId");
            Property(i => i.SubcategoryId).HasColumnName("SubcategoryId");
            Property(i => i.Price).HasColumnName("Price");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Image).HasColumnName("Image");
            Property(i => i.Rating).HasColumnName("Rating");
           
        }
    }
}
 