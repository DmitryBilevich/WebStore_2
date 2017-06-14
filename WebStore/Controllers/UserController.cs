using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.WorkService;

namespace WebStore.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(User user)
        {
            UserService userService = new UserService();
            userService.CreateAccount(user);
            return View("Index");
        }
        [HttpPost]
        public JsonResult CreateAccount(User user)
        {
            Response response=new Response();
            UserService userService = new UserService();
            response = userService.CreateAccount(user);
            return Json(response);
        }

        public class Response
        {
            public string Massange { get; set; }
            public bool IsCreate { get; set; }
        }
    }
}
