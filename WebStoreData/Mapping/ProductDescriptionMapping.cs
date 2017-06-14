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
    public class ProductDescriptionMapping : EntityTypeConfiguration<ProductDescription>
    {
        public ProductDescriptionMapping()
        {
            ToTable("ProductDescription");
            HasKey(i => new { i.Id });

            Property(i => i.Id).HasColumnName("Id");
            Property(i => i.ProductId).HasColumnName("ProductId");
            Property(i => i.IsShort).HasColumnName("IsShort");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Text).HasColumnName("Text");
            
           
        }
    }
}
