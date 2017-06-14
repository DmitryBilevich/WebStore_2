using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class ProductPicture
    {
        public string Picture { get; set; }
        public int ProductId { get; set; }
        public int PictureId { get; set; }
    }
}