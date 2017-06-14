using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
    public class Section
    {
        public Section()
        {
            Categories = new List<Category>();
        }
        public virtual ICollection<Category> Categories { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsLongText { get; set; }
        public int SectionId { get; set; }
        public int Order { get; set; }
        
        //public IEnumerable<Category> Categories { get; set; }
    }
}
