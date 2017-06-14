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
    public class ProductPictureMapping : EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureMapping()
        {
            ToTable("ProductPicture");
            HasKey(i => new { i.PictureId });

            Property(i => i.PictureId).HasColumnName("PictureId");
            Property(i => i.Picture).HasColumnName("Picture");
            Property(i => i.ProductId).HasColumnName("ProductId");
        }
    }
}
