using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class ProductPictureRepository
    {private BaseContext context;

    public ProductPictureRepository()
        {
            context=new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString );
        }

        public IEnumerable<ProductPicture> GetProductPictures()
        {
            return context.ProductPictures;
        }

        public ProductPicture GetProductPictureById(int pictureId)
        {
            return context.ProductPictures.FirstOrDefault(ProductPicture => ProductPicture.ProductId == pictureId);
        }

        public void Create(ProductPicture productPicture)
        {
            context.ProductPictures.Add(productPicture);
            context.SaveChanges();
        }

        public void DeleteProductDescription(int Id)
        {
            ProductPicture productPicture = context.ProductPictures.FirstOrDefault(i => i.PictureId == Id);
            if (productPicture != null)
            {
                context.ProductPictures.Remove(productPicture);
                context.SaveChanges();
            }
        }

        public void Edit(ProductPicture productPicture)
        {
            ProductPicture editProductPicture = context.ProductPictures.Find(productPicture.PictureId);
            editProductPicture.Picture = productPicture.Picture;
            editProductPicture.ProductId = productPicture.ProductId;
            context.SaveChanges();
        }
    }
}
