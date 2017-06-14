using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class CategoryRepositry
    {
        private BaseContext context;

        public CategoryRepositry()
        {
            context = new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString);
        }
        public IEnumerable<Category> GetCategories()
        {
            return context.Category;
        }

        public Category GetCategoriesId(int categoryId)
        {
            return context.Category.FirstOrDefault(category => category.CategoryId == categoryId);
        }

        public void CreateCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = context.Category.FirstOrDefault(i => i.CategoryId == categoryId);
            if (category != null)
            {
                context.Category.Remove(category);
                context.SaveChanges();
            }
        }

        public void Edit(Category category)
        {
            Category editCategory = context.Category.Find(category.CategoryId);
            editCategory.Name = category.Name;
            editCategory.Url = category.Url;
            editCategory.CategoryId = category.CategoryId;
            context.SaveChanges();
        }
    }
}
