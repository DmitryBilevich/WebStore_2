using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebStore.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        [JsonProperty(PropertyName = "shortDescriptions")]
        public List<string> ShortDescriptions { get; set; }
         [JsonProperty(PropertyName = "pictures")]
        public List<string> Pictures { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public List<ProductDescription> Descriptions { get; set; }
    }
}