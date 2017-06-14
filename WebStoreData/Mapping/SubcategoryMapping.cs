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
    public class SubcategoryMapping : EntityTypeConfiguration<Subcategory>
    {
        public SubcategoryMapping()
        {
            ToTable("Subcategory");
            HasKey(i => new { i.SubcategoryId });

            Property(i => i.SubcategoryId).HasColumnName("SubcategoryId");
            Property(i => i.CategoryId).HasColumnName("CategoryId");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Url).HasColumnName("Url");
            Property(i => i.Image).HasColumnName("Image");
            
           
        }
    }
}
