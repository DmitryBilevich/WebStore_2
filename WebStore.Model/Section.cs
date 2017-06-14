using System.Collections.Generic;

namespace WebStore.Model
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