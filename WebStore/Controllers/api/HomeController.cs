using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using  WebStore.Models;
using WebStore.WorkService;
using WebStoreData.Models;
using WebStoreData.Repository;

namespace WebStore.Controllers.api
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            HomeService homeService=new HomeService();
            var model =homeService.GetProductListing();
            string result = JsonConvert.SerializeObject(model);
            return result;
        }
        

        // POST api/<controller>
        public void Post([FromBody]WebStore.Models.ProductListing value)
        {
            //SectionRepository sectionRepository=new SectionRepository();
            //var sectionList = sectionRepository.GetSections().ToList();
            //foreach (var item in value.Sections)
            //{
            //    foreach ( var x in item.Categories)
            //    {
                    
            //    }
            //    WebStoreData.Models.Category setSection = new WebStoreData.Models.Category();
                
            //}
            //CategoryRepositry categoryRepositry=new CategoryRepositry();
            //SectionRepository sectionRepository = new SectionRepository();
            //List<WebStoreData.Models.Section> sections = sectionRepository.GetSections().ToList();
            //foreach (var item in value.Sections)
            //{
            //    WebStoreData.Models.Section section = sections.FirstOrDefault(i => i.Name == item.Name);
            //    foreach (var category in item.Categories)
            //    {
            //        WebStoreData.Models.Category newCategory = new WebStoreData.Models.Category();
            //        newCategory.CategoryId = category.CategoryId;
            //        newCategory.Name = category.Name;
            //        newCategory.Url = category.Url;
            //        newCategory.SectionId = section.SectionId;
            //        categoryRepositry.CreateCategory(newCategory);
            //    }
                
            //}
            //SubcategoryRepository subcategoryRepository=new SubcategoryRepository();
            //CategoryRepositry categoryRepositry = new CategoryRepositry();
            //var categories = categoryRepositry.GetCategories().ToList();
            //foreach (var section in value.Sections)
            //{
            //    foreach (var category in section.Categories)
            //    {
            //        WebStoreData.Models.Category categoryDb = categories.FirstOrDefault(i => i.Name == category.Name);
            //        foreach (var subcategory in category.SubCategories)
            //        {
            //            WebStoreData.Models.Subcategory newSubcategory = new WebStoreData.Models.Subcategory();
            //            newSubcategory.SubcategoryId = subcategory.SubcategoryId;
            //            newSubcategory.Name = subcategory.Name;
            //            newSubcategory.Image = subcategory.Image;
            //            newSubcategory.Url = subcategory.Url;
            //            newSubcategory.CategoryId = categoryDb.CategoryId;
                       // subcategoryRepository.Create(newSubcategory);
            //        }
            //    }
            //}
            //ProductRepository productRepository =new ProductRepository();
            //SubcategoryRepository subcategoryRepository = new SubcategoryRepository();
            //CategoryRepositry categoryRepositry = new CategoryRepositry();
            //var categories = categoryRepositry.GetCategories().ToList();
            //var subCategories = subcategoryRepository.GetSubcategories().ToList();
            //foreach (var section in value.Sections)
            //{
            //    foreach (var category in section.Categories)
            //    {
            //        WebStoreData.Models.Category categoryDb = categories.FirstOrDefault(i => i.Name == category.Name);
            //        foreach (var subCategory in category.SubCategories)
            //        {
            //            WebStoreData.Models.Subcategory subCategoryDb = subCategories.FirstOrDefault(i => i.Name == subCategory.Name);
            //            foreach (var product in subCategory.Products)
            //            {
            //                WebStoreData.Models.Product newProduct = new WebStoreData.Models.Product();
            //                newProduct.SubcategoryId = subCategoryDb.SubcategoryId;
            //                newProduct.Name = product.Name;
            //                newProduct.Image = product.Image;
            //                newProduct.Price = product.Price;
            //                newProduct.Rating = product.Rating;
            //                newProduct.CategoryId = categoryDb.CategoryId;
            //                productRepository.Create(newProduct);
            //            }
            //        }
            //    }
            //}
            //ProductRepository productRepository = new ProductRepository();

            //ProductPictureRepository productPictureRepository = new ProductPictureRepository();
            
            
            //var products = productRepository.GetProducts().ToList();
            //foreach (var section in value.Sections)
            //{
            //    foreach (var category in section.Categories)
            //    {
            //        foreach (var subCategory in category.SubCategories)
            //        {
            //            foreach (var product in subCategory.Products)
            //            {
            //                WebStoreData.Models.Product productDb = products.FirstOrDefault(i => i.Name == product.Name);

            //                foreach (var picture in product.Pictures)
            //                {
            //                    WebStoreData.Models.ProductPicture newProductPicture = new WebStoreData.Models.ProductPicture();
            //                    newProductPicture.ProductId = productDb.ProductId;
            //                    newProductPicture.Picture = picture;
            //                    productPictureRepository.Create(newProductPicture);
            //                }                           
            //            }
            //        }
            //    }
            //}
        }
        
        
    }

    //CategoryRepositry categoryRepositry=new CategoryRepositry();
    //        SubcategoryRepository subcategoryRepository = new SubcategoryRepository();
    //        ProductRepository productRepository =new ProductRepository();
    //public class ProductListing
    //{

    //    public List<Section> Sections { get; set; }
    //}

    //public class Section
    //{
    //    public string Name { get; set; }
    //    public string Url { get; set; }
    //    public bool IsLongText { get; set; }
    //    public List<Category> Categories { get; set; }
    //}

    //public class Category
    //{
    //    public string Name { get; set; }
    //    public string Url { get; set; }
    //    public List<SubCategory> SubCategories { get; set; } 
        
    //}
    //public class SubCategory
    //{
    //    public string Name { get; set; }
    //    public string Url { get; set; }
    //    public string Image { get; set; }
    //    public List<Product> Products { get; set; }

    //}

    //public class Product
    //{
    //    public string Name { get; set; }
    //    public string Price { get; set; }
    //    public string Image { get; set; }
    //    public string Rating { get; set; }
    //    public List<string> ShortDiscriptions { get; set; }
    //    public List<string> Pictures { get; set; }
    //    public List<ProductDescription> Descriptions { get; set; }
    //}

    //public class ProductDescription
    //{
    //    public string Name { get; set; }
    //    public string Text { get; set; }
    //}
}