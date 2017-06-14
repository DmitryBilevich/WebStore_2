using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
    public class ProductDescription
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsShort { get; set; }
        public int ProductId { get; set; }
        public int Id { get; set; }
        public virtual Product Product { get; set; }
    }
}
