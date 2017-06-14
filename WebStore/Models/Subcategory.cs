using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebStore.Models
{
    public class Subcategory
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        [JsonProperty(PropertyName = "products")]
        public List<Product> Products { get; set; }
    }
}