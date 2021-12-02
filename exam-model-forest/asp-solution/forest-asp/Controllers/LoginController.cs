using forest_asp.DataAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace forest_asp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("ViewLogin");
        }

        public ActionResult Login()
        {
            string user = Request.Params["user"];
            string password = Request.Params["password"];
            DAL dal = new DAL();
            bool result = dal.login(user,password);
            int uid = dal.GetUserIdOfUser(user);
            return Json(new { success = result, userId = uid });
        }
    }
}