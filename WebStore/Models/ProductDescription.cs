using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebStore.Models
{
    public class ProductDescription
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        public bool IsShort { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
}