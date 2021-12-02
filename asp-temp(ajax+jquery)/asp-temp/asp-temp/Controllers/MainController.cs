using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_temp.DataAbstractionLayer;
using asp_temp.Models;
namespace asp_temp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("MainView");
        }

        public ActionResult GetChildrenOfParent()
        {
            string name = Request.Params["parentname"];
            DAL dal = new DAL();
            List<Child> child = dal.GetChildrenByParentName(name);
            return Json( new {children = child},  JsonRequestBehavior.AllowGet);
        }
    }
}