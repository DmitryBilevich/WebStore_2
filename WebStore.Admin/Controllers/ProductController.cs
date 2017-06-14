using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreData.Models;
using WebStore.Admin.Models;
using WebStore.Admin.WorkServise;
using WebStore.Admin.Models.Product;

namespace WebStore.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ProductServise productServise=new ProductServise();
            ProductListViewModel model = new ProductListViewModel();
            model = productServise.GetProductViewModel();
            return View("Product", model);
        }

        [HttpPost]
        public bool UpdateProduct(Product product)
        {
            ProductServise productServise=new ProductServise();
            bool result = productServise.UpdateProduct(product);
            return result;
        }
    }
}
