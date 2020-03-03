using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Souq2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Single_Product()
        {
            return View();
        }
    }
}