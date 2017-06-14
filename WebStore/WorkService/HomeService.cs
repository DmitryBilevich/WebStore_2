using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Models;
using WebStoreData.Models;
using WebStoreData.Repository;
using Category = WebStore.Models.Category;
using Product = WebStore.Models.Product;
using ProductDescription = WebStore.Models.ProductDescription;
using ProductPicture = WebStore.Models.ProductPicture;
using Section = WebStore.Models.Section;
using Subcategory = WebStore.Models.Subcategory;


namespace WebStore.WorkService
{
    public class HomeService
    {
        public ProductListing GetProductListing()
        {
            ProductListing productListing=new ProductListing();
            productListing.Sections= new List<Section>();
            SectionRepository sectionRepository=new SectionRepository();
            
            List<WebStoreData.Models.Section> sectionsDB = sectionRepository.GetSections().ToList();
            


            foreach (var sectionDB in sectionsDB)
            {
                WebStore.Models.Section section= new Section();
                section.Name = sectionDB.Name;
                section.IsLongText = sectionDB.IsLongText;
                section.SectionId = sectionDB.SectionId;
                section.Url = sectionDB.Url;
                section.Order = sectionDB.Order;
                productListing.Sections.Add(section);
                section.Categories=new List<Category>();
                foreach (var categoryDB in sectionDB.Categories)
                {
                    WebStore.Models.Category category=new Category();
                    category.Name = categoryDB.Name;
                    category.SectionId = categoryDB.SectionId;
                    category.CategoryId = categoryDB.CategoryId;
                    category.Url = categoryDB.Url;
                    if (category.SectionId == section.SectionId)
                    {
                        section.Categories.Add(category);
                    }
                    category.SubCategories=new List<Subcategory>();
                    foreach(var subcategoryDB in categoryDB.Subcategories)
                    {
                        WebStore.Models.Subcategory subcategory=new Subcategory();
                        subcategory.Name = subcategoryDB.Name;
                        subcategory.Image = subcategoryDB.Image;
                        subcategory.CategoryId = subcategoryDB.CategoryId;
                        subcategory.SubcategoryId = subcategoryDB.SubcategoryId;
                        subcategory.Url = subcategoryDB.Url;
                        if (subcategory.CategoryId == category.CategoryId)
                        {
                            category.SubCategories.Add(subcategory);
                        }
                        subcategory.Products=new List<Product>();
                        foreach (var productDB in subcategoryDB.Products)
                        {
                           WebStore.Models.Product product=new Product();
                            product.Name = productDB.Name;
                            product.Price = productDB.Price;
                            product.Image = productDB.Image;
                            product.Rating = productDB.Rating;
                            product.SubcategoryId = productDB.SubcategoryId;
                            product.ProductId = productDB.ProductId;
                            if (product.SubcategoryId == subcategory.SubcategoryId)
                            {
                                subcategory.Products.Add(product);
                            }
                            product.Descriptions=new List<ProductDescription>();
                            //product.ShortDiscription=new List<ProductDescription>();
                            product.Pictures=new List<string>();
                            foreach (var productDescriptionDB in productDB.ProductDescriptions)
                           {
                                 WebStore.Models.ProductDescription productDescription =new  WebStore.Models.ProductDescription();
                                 
                                productDescription.Name = productDescriptionDB.Name;
                                productDescription.Text = productDescriptionDB.Text;
                                productDescription.IsShort = productDescriptionDB.IsShort;
                                productDescription.ProductId = productDescriptionDB.ProductId;
                                product.Descriptions.Add(productDescription);
                                
                                    if (productDescription.IsShort == true)
                                    {
                                        string shortDescription = productDescriptionDB.Name + ":" + productDescriptionDB.Text;
                                        product.ShortDescriptions.Add(shortDescription);
                                    }
                                
                            }

                            foreach (var productPictureDB in productDB.ProductPictures)
                            {
                                    product.Pictures.Add(productPictureDB.Picture);                            
                            }
                        }
                    }
                }
            }
            productListing.Sections = productListing.Sections.OrderBy(x => x.Order).ToList();
            return productListing;
        }

    }
}