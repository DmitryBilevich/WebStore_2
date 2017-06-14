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
    public class SectionMapping : EntityTypeConfiguration<Section>
    {
        public SectionMapping()
        {
            ToTable("Section");
            HasKey(i => new { i.SectionId });

            Property(i => i.SectionId).HasColumnName("SectionId");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Url).HasColumnName("Url");
            Property(i => i.IsLongText).HasColumnName("IsLongText");
            Property(i => i.Order).HasColumnName("Order");
           
        }
    }
}
