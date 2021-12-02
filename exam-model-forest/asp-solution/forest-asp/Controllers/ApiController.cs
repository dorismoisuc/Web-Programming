using forest_asp.DataAbstractionLayer;
using forest_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace forest_asp.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View("ViewApi");
        }
        public ActionResult GetCoursesOfUser()
        {

            DAL dal = new DAL();
            int uid = int.Parse(Request.Params["userId"]);
            List<Course> assetsList = dal.getCoursesOfUser(uid);
            return Json(new { courses = assetsList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentsCourses()
        {

            DAL dal = new DAL();
            string name = (Request.Params["student"]);
            List<Course> assetsList = dal.getCoursesOfStudent(name);
            return Json(new { courses = assetsList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GradeStudent()
        {
            DAL dal = new DAL();
            int courseId = int.Parse(Request.Params["courseId"]);
            int grade = int.Parse(Request.Params["grade"]);
            string studentName = Request.Params["name"];
            bool result = dal.GradeStudent(courseId,studentName, grade);
            return Json(new { success = result });
        }
    }
}