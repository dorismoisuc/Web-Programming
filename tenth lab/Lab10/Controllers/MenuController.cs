using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewMenu");
        }
    }
}