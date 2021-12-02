using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_app.Models
{
    public class Course
    {
        private int id;
        private int professorId;
        private string courseName;
        private string participants;
        private string grades;

        public int Id { get => id; set => id = value; }
        public int ProfessorId { get => professorId; set => professorId = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public string Participants { get => participants; set => participants = value; }
        public string Grades { get => grades; set => this.grades = value; }
    }
}