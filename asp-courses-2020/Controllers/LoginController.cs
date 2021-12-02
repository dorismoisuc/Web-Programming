using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_app.DataAbstractionLayer;

namespace asp_app.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            string user = Request.Params["user"];
            DAL dal = new DAL();
            bool result = dal.login(user);
            int uid = dal.GetUserIdOfUser(user);
            return Json(new { success = result, userId = uid });
        }


    }
}