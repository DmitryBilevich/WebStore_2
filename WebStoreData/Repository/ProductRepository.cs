using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class ProductRepository
    {
        private BaseContext context;
        public ProductRepository()
        {
            context = new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString);
        }
        public IEnumerable<Product> GetProducts()
        {
            return context.Product;
        }

        public Product GetProductById(int productId)
        {
            return context.Product.FirstOrDefault(product => product.ProductId == productId);
        }

        public void Create(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void Delete(int productyId)
        {
            Product product = context.Product.FirstOrDefault(i => i.ProductId == productyId);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            Product editProduct = context.Product.Find(product.ProductId);
            editProduct.Name = product.Name;
            editProduct.Price = product.Price;
            //editProduct.Image = product.Image;
            editProduct.Rating = product.Rating;
            //editProduct.ProductId = product.ProductId;
            //editProduct.CategoryId = product.CategoryId;
            //editProduct.SubcategoryId = product.SubcategoryId;
            context.SaveChanges();
        }

        
        //public IEnumerable<ProductDescription> GetProductDescriptions()
        //{
        //    return context.ProductDescription;
        //}

        //public IEnumerable<ProductShortDescription> GetProductShortDescriptions()
        //{
        //    return context.ProductShortDescription;
        //}

        //public void SetProdct(Product product)
        //{
        //    context.Product.Add(product);
        //}

        //public void SetProductDescription(ProductDescription productDescription)
        //{
        //    context.ProductDescription.Add(productDescription);
        //}

        //public void SetProductShortDescription(ProductShortDescription productShortDescription)
        //{
        //    context.ProductShortDescription.Add(productShortDescription);
        //}

        //public void SetProductPicture(ProductPicture productPicture)
        //{
        //    context.ProductPictures.Add(productPicture);
        //}
    }
}
