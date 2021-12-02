using Lab8.Data_Abstraction_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewLogin");
        }

        public ActionResult Login()
        {
            string user = Request.Params["user"];
            string pwd = Request.Params["pwd"];
            DAL dal = new DAL();
            bool result = dal.login(user, pwd);
            return Json(new { success = result });
        }
        
    }
}