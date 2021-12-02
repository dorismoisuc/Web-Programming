using Lab8.Data_Abstraction_Layer;
using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class BrowseController : Controller
    {

        private int totalEntries;
        // GET: Browse
        public ActionResult Index()
        {
            return View("ViewBrowse");
        }

        public ActionResult GetPage()
        {
            DAL dal = new DAL();
            int currentPage = int.Parse(Request.Params["pageNo"]);
            int pageSize = int.Parse(Request.Params["pageSize"]);
            List<LogReport> reportsList = dal.GetReportsOnPage(currentPage, pageSize, totalEntries);
            return Json(new { reports = reportsList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NextPage()
        {
            DAL dal = new DAL();
            int currentPage = int.Parse(Request.Params["pageNo"]);
            int pageSize = int.Parse(Request.Params["pageSize"]);
            totalEntries = dal.GetLogReports().Count;
            int acceptableSize = (int) Math.Ceiling((double)totalEntries / pageSize);
            if (currentPage < acceptableSize - 1)
            {
                currentPage++;
                return Json(new { success = "yes", page=currentPage }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = "no" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PreviousPage()
        {
            DAL dal = new DAL();
            totalEntries = dal.GetLogReports().Count;
            int currentPage = int.Parse(Request.Params["pageNo"]);
            int pageSize = int.Parse(Request.Params["pageSize"]);
            if (currentPage > 0)
            {
                currentPage--;
                return Json(new { success = "yes", page = currentPage }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = "no" }, JsonRequestBehavior.AllowGet);
        }
    }
}