using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class SubcategoryRepository
    {
        private BaseContext context;

        public SubcategoryRepository()
        {
            context = new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString);
        }

        public IEnumerable<Subcategory> GetSubcategories()
        {
            return context.Subcategory;
        }

        public Subcategory GetSubcategoriesId(int subcategoryId)
        {
            return context.Subcategory.FirstOrDefault(subcategory => subcategory.SubcategoryId == subcategoryId);
        }

        public void Create(Subcategory subcategory)
        {
            context.Subcategory.Add(subcategory);
            context.SaveChanges();
        }

        public void Delete(int subcategoryId)
        {
            Subcategory subcategory = context.Subcategory.FirstOrDefault(i => i.SubcategoryId == subcategoryId);
            if (subcategory != null)
            {
                context.Subcategory.Remove(subcategory);
                context.SaveChanges();
            }
        }

        public void Edit(Subcategory subcategory)
        {
            Subcategory editSubcategory = context.Subcategory.Find(subcategory.SubcategoryId);
            editSubcategory.Name = subcategory.Name;
            editSubcategory.Url = subcategory.Url;
            editSubcategory.CategoryId = subcategory.CategoryId;
            editSubcategory.SubcategoryId = subcategory.SubcategoryId;
            editSubcategory.Image = subcategory.Image;
            context.SaveChanges();
        }
    }
}
