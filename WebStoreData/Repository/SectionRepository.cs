using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreData.Models;
using System.Configuration;

namespace WebStoreData.Repository
{
    public class SectionRepository
    {
        private BaseContext context;

        public SectionRepository()
        {
            context = new BaseContext(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString);
        }

        public IEnumerable<Section> GetSections()
        {
            return context.Section;
        }

        public void CreateSection(Section section)
        {
            context.Section.Add(section);
            context.SaveChanges();
        }

        public void DeleteSecion(int sectionId)
        {
            Section section = context.Section.FirstOrDefault(i => i.SectionId == sectionId);
            if (section != null)
            {
                context.Section.Remove(section);
                context.SaveChanges();
            }
        }

        public void Edit(Section section)
        {
            Section editSection = context.Section.Find(section.SectionId);
            editSection.Name = editSection.Name;
            editSection.Url = editSection.Url;
            editSection.IsLongText = section.IsLongText;
            context.SaveChanges();
        }
    }
}
