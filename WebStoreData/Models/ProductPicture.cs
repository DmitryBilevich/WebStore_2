using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreData.Models
{
    public class ProductPicture
    {
        public string Picture { get; set; }
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public virtual Product Product { get; set; }
    }
}
