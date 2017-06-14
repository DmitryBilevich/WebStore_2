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
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Category");
            HasKey(i => new { i.CategoryId });

            Property(i => i.CategoryId).HasColumnName("CategoryId");
            Property(i => i.SectionId).HasColumnName("SectionId");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Url).HasColumnName("Url");
            
           
        }
    }
}
