using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_app.DataAbstractionLayer;
using asp_app.Models;
using System.Diagnostics;

namespace asp_app.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View("MainPage");
        }

        public string Test()
        {
            return "It's working";
        }

        public string GetCourseParticipants()
        {
            string coursename = Request.Params["coursename"];
            DAL dal = new DAL();

            List<string> names = dal.GetParticipantsNames(coursename);
            //ViewData["studentList"] = names;

            string result = "<ul>";

            foreach (string name in names)
            {
                result += "<li>" + name + "</li>";
            }

            result += "</ul>";
            return result;
        }

        public string GetStudentCourses()
        {
            string studentname = Request.Params["studentname"];
            DAL dal = new DAL();
            int student_id = dal.GetUserIdOfUser(studentname);

            List<Course> slist = dal.GetStudentCourses(student_id);
            //ViewData["studentList"] = slist;

            string result = "<table><thead><th>ID</th><th>ProfessorID</th><th>Cousename</th><th>Participants</th><th>Grades</th></thead>";

            foreach (Course c in slist)
            {
                result += "<tr><td>" + c.Id + "</td><td>" + c.ProfessorId + "</td><td>" + c.CourseName + "</td><td>" + c.Participants + "</td><td>" + c.Grades + "</td></tr>";
            }

            result += "</table>";
            return result;
        }

        public string GradeStudent()
        {
            string result = "";
            DAL dal = new DAL();
            int course_id = Int32.Parse(Request.Params["courseid"]);
            int student_id = dal.GetUserIdOfUser(Request.Params["studentname"]);
            string studIdStr = student_id.ToString();
            string grade = Request.Params["grade"];
            int professorID = Int32.Parse(Request.Params["professorid"]);

            //Debug.WriteLine("Prof: " + professorID);
            Course c = dal.GetCourse(course_id);
            if (professorID != c.ProfessorId)
            {
                result = "This is not your course!";
                return result;
            }
            String[] partIds = c.Participants.Split(',');
            if (!partIds.Contains(studIdStr))
                c.Participants = c.Participants + "," + studIdStr;

            String[] grades = c.Grades.Split(',');
            String finalGrades = "";
            Boolean found = false;
            foreach(String g in grades)
            {
                if(g.Length > 2)
                {
                    String[] gradeTuple = g.Split(':');
                    if (gradeTuple[0] == studIdStr)
                    {
                        found = true;
                        gradeTuple[1] = grade;
                    }
                    finalGrades += gradeTuple[0] + ":" + gradeTuple[1] + ",";
                }
            }
            if (!found)
                finalGrades += studIdStr + ":" + grade;
            c.Grades = finalGrades;
            dal.updateCourse(c);

            result = "Student graded successfully";
            return result;
        }
    }
}