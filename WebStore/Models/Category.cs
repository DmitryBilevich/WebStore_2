using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebStore.Models
{
    public class Category
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public int SectionId { get; set; }
        [JsonProperty(PropertyName = "subCategories")]
        public List<Subcategory> SubCategories { get; set; }
    }
}