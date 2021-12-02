using Lab8.Data_Abstraction_Layer;
using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewLogReport");
        }

        public ActionResult GetTypes()
        {
            DAL dal = new DAL();
            List<string> typesList = dal.GetAllTypes(Request.Params["username"]);
            return Json(new { types = typesList }, JsonRequestBehavior.AllowGet);
         }
        public ActionResult GetSeverities()
        {
            DAL dal = new DAL();
            List<string> severitiesList = dal.GetAllSeverities(Request.Params["username"]);
            return Json(new { severities = severitiesList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReports()
        {
            DAL dal = new DAL();
            List<LogReport> slist = dal.GetLogReports();
            return Json(new { reports = slist }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReportsOfUser()
        {
            DAL dal = new DAL();
            System.Diagnostics.Debug.WriteLine(Request.Params["username"]);
            List<LogReport> slist = dal.GetLogReportsOfUser(Request.Params["username"]);
            return Json(new { reports = slist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteReport()
        {
            DAL dal = new DAL();
            bool result = dal.DeleteLogReport(int.Parse(Request.Params["id"]));
            return Json(new { success=result });
        }

        public ActionResult SaveReport()
        {
            DAL dal = new DAL();
            LogReport log = new LogReport();
            log.User_id = dal.GetUserIdOfUser(Request.Params["username"]);
            log.Date = Request.Params["date"];
            log.Severity = Request.Params["severity"];
            log.Type = Request.Params["type"];
            
            bool result = dal.AddLogReport(log);
            return Json(new { success = result });
        }

        public ActionResult GetReportsOfType()
        {
            string type =(Request.Params["type"]);
            string user = Request.Params["user"];
            DAL dal = new DAL();
            List<LogReport> slist = dal.GetReportsOfType(type,user);
            return Json(new { reports = slist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReportsOfSeverity()
        {
            string severity = (Request.Params["severity"]);
            string user = Request.Params["user"];
            DAL dal = new DAL();
            List<LogReport> slist = dal.GetReportsOfSeverity(severity, user);
            return Json(new { reports = slist }, JsonRequestBehavior.AllowGet);
        }
    }
}