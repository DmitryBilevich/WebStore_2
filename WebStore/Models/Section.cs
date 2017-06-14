using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class Section
    {
        
        public string Name { get; set; }
        public int SectionId { get; set; }
        public string Url { get; set; }
        public bool IsLongText { get; set; }
        public List<Category> Categories { get; set; }
        public int Order { get; set; }
        
    }
}