using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmitMapper.MappingConfiguration;
using WebStore.Admin.Models.Product;
using WebStoreData.Models;
using WebStore.Model;
using WebStoreData.Repository;
using WebStoreData.Models;
using EmitMapper;
using Category = WebStore.Model.Category;
using Product = WebStore.Model.Product;
using ProductDescription = WebStore.Model.ProductDescription;
using Section = WebStore.Model.Section;
using Subcategory = WebStore.Model.Subcategory;


namespace WebStore.Admin.WorkServise
{
    public class ProductServise
    {
        public ProductListViewModel GetProductViewModel()
        {
            ProductListViewModel productViewModel=new ProductListViewModel();
            productViewModel.Products=new List<Product>();
             productViewModel.Sections=new List<Section>();
             productViewModel.Categories=new List<Category>();
             productViewModel.Subcategories=new List<Subcategory>();
            ProductRepository productRepository=new ProductRepository();
            SectionRepository sectionRepository = new SectionRepository();
            CategoryRepositry categoryRepository = new CategoryRepositry();
            SubcategoryRepository subcategoryRepository = new SubcategoryRepository();
            List<WebStoreData.Models.Product> products = productRepository.GetProducts().ToList();
            List<WebStoreData.Models.Section> sections = sectionRepository.GetSections().ToList();
            List<WebStoreData.Models.Category> categories = categoryRepository.GetCategories().ToList();
            List<WebStoreData.Models.Subcategory> subcategories = subcategoryRepository.GetSubcategories().ToList();
            var productMapper = ObjectMapperManager.DefaultInstance.GetMapper<WebStoreData.Models.Product, WebStore.Model.Product>();
            var productDescriptionMapper = ObjectMapperManager.DefaultInstance.GetMapper<WebStoreData.Models.ProductDescription, WebStore.Model.ProductDescription>();

            var sectionMapper = ObjectMapperManager.DefaultInstance.GetMapper<WebStoreData.Models.Section, WebStore.Model.Section>(new DefaultMapConfig().IgnoreMembers<WebStoreData.Models.Section, WebStore.Model.Section>(new []{"Categories"}));
            var categoryMapper = ObjectMapperManager.DefaultInstance.GetMapper<WebStoreData.Models.Category, WebStore.Model.Category>(new DefaultMapConfig().IgnoreMembers<WebStoreData.Models.Category, WebStore.Model.Category>(new []{"Subcategories"}));
            var subcategoryMapper = ObjectMapperManager.DefaultInstance.GetMapper<WebStoreData.Models.Subcategory, WebStore.Model.Subcategory>(new DefaultMapConfig().IgnoreMembers<WebStoreData.Models.Subcategory, WebStore.Model.Subcategory>(new []{"Products"}));

            foreach (var sectionItem in sections)
            {
                WebStore.Model.Section section = sectionMapper.Map(sectionItem);
                 productViewModel.Sections.Add(section);
            }

            foreach (var categoryItem in categories)
            {
                WebStore.Model.Category category = categoryMapper.Map(categoryItem);
                 productViewModel.Categories.Add(category);
            }

            foreach (var subcategoryItem in subcategories)
            {
                WebStore.Model.Subcategory subcategory = subcategoryMapper.Map(subcategoryItem); 
                 productViewModel.Subcategories.Add(subcategory);
            }

            foreach (var item in products)
            {
                WebStore.Model.Product product = productMapper.Map(item);

                product.Descriptions=new List<ProductDescription>();
                product.ShortDescriptions=new List<string>();
                product.Pictures = new List<string>();
                int sectionId = 0;
                    foreach (var subcategory in subcategories)
                {
                    if (item.SubcategoryId == subcategory.SubcategoryId)
                    {
                        product.Subcategory = subcategory.Name;
                    }
                }

                    foreach (var category in categories)
                {
                    if (item.CategoryId == category.CategoryId)
                    {
                        product.Category = category.Name;
                        sectionId = category.SectionId;
                    }
                }

                foreach (var section in sections)
                {
                    if (sectionId == section.SectionId)
                    {
                        product.Section = section.Name;
                    }
                }

                foreach (var description in item.ProductDescriptions)
                {
                    if (description.IsShort)
                    {
                        
                        string shortDescription = description.Name + ":" + description.Text;
                        product.ShortDescriptions.Add(shortDescription);
                    }
                    else
                    {
                        WebStore.Model.ProductDescription productDescription = productDescriptionMapper.Map(description);
                        product.Descriptions.Add(productDescription); 
                    }

                }

                
                foreach (var picture in item.ProductPictures)
                {
                    product.Pictures.Add(picture.Picture);
                }
                productViewModel.Products.Add(product);
            }
            return productViewModel;
        }

        public bool UpdateProduct(WebStoreData.Models.Product product)
        {
            bool result = true;
            WebStoreData.Repository.ProductRepository productRepository=new ProductRepository();
            try
            {
                productRepository.Edit(product);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}