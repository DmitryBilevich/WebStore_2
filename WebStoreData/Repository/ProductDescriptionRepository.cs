using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class ProductDescriptionRepository
    {
        private BaseContext context;

        public ProductDescriptionRepository()
        {
            context=new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString );
        }

        public IEnumerable<ProductDescription> GetProductDescriptions()
        {
            return context.ProductDescription;
        }

        public ProductDescription GetProductDescriptionsById(int productId)
        {
            return context.ProductDescription.FirstOrDefault(productDescription => productDescription.ProductId == productId);
        }

        public void Create(ProductDescription productDescription)
        {
            context.ProductDescription.Add(productDescription);
            context.SaveChanges();
        }

        public void DeleteProductDescription(int Id)
        {
            ProductDescription productDescription = context.ProductDescription.FirstOrDefault(i => i.Id == Id);
            if (productDescription != null)
            {
                context.ProductDescription.Remove(productDescription);
                context.SaveChanges();
            }
        }

        public void Edit(ProductDescription productDescription)
        {
            ProductDescription editProductDescription = context.ProductDescription.Find(productDescription.Id);
            editProductDescription.Name = productDescription.Name;
            editProductDescription.Text = productDescription.Text;
            editProductDescription.IsShort = productDescription.IsShort;
            editProductDescription.ProductId = productDescription.ProductId;
            context.SaveChanges();
        }
    }
}
