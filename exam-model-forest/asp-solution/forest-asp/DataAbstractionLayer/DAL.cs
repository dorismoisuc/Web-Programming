using forest_asp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace forest_asp.DataAbstractionLayer
{
    public class DAL
    {
        public MySqlConnection getConnection()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;pwd=;database=assetsdb;";
            return new MySqlConnection(myConnectionString);

        }

        public bool login(string user, string password)
        {

            List<String> users = new List<String>();

            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + user + "' and password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    users.Add(myreader.GetString("username"));
                }

                conn.Close();
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
            return users.Count == 1;

        }

        public bool SaveAsset(Asset asset)
        {
            MySqlConnection connection;
            int rowsAffected = 0;
            try
            {
                connection = getConnection();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into assets(userid, name, description, value) values("
                    + asset.Userid + ",\'" + asset.Name + "\',\'" + asset.Description + "\'," + asset.Value + ")";
                rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
                return false;

            }
            return rowsAffected == 1;
        }
        public int GetUserIdOfUser(string user)
        {
            int report = 0;
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select id from users where username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    report = myreader.GetInt32("id");
                }

                myreader.Close();

                conn.Close();
            }
            catch (MySqlException e)
            {
                Debug.Write(e);
            }
            return report;
        }

        public List<Asset> getAssetsOfUser(int userId)
        {
            List<Asset> lst = new List<Asset>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select id,name,description, value from assets where userid=" + userId  ;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Asset asset = new Asset();
                    asset.Id = myreader.GetInt32("id");
                    asset.Userid = userId;
                    asset.Name = myreader.GetString("name");
                    asset.Description = myreader.GetString("description");
                    asset.Value = myreader.GetInt32("value");
                    lst.Add(asset);
                }

                myreader.Close();

                conn.Close();
            }
            catch (MySqlException e)
            {

            }
            return lst;
        }

        public List<Course> getCoursesOfUser(int userId)
        {
            List<Course> lst = new List<Course>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select id,coursename,participants, grades from courses where professorid=" + userId;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Course course = new Course();
                    course.Id = myreader.GetInt32("id");
                    course.ProfessorId = userId;
                    course.CourseName = myreader.GetString("coursename");
                    course.Participants = myreader.GetString("participants");
                    course.Grades = myreader.GetString("grades");
                    lst.Add(course);
                }

                myreader.Close();

                conn.Close();
            }
            catch (MySqlException e)
            {

            }
            return lst;
        }

        internal bool GradeStudent(int courseId, string studentName, int grade)
        {
            MySqlConnection connection;
            int rowsAffected = 0;
            try
            {
                connection = getConnection();
                connection.Open();
                string participants = getParticipantsOfCourse(courseId);
                string grades = getGradesOfCourse(courseId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE courses SET participants='" + participants + "," + studentName + "', grades='" + grades + "," + grade + "' where id=" + courseId;
                rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
                return false;

            }
            return rowsAffected == 1;
        }

        private string getGradesOfCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        private string getParticipantsOfCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> getCoursesOfStudent(string name)
        {
            List<Course> lst = new List<Course>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select id,coursename,participants, grades from courses where participants LIKE '%" + name + "%'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Course course = new Course();
                    course.Id = myreader.GetInt32("id");
                    course.CourseName = myreader.GetString("coursename");
                    course.Participants = myreader.GetString("participants");
                    course.Grades = myreader.GetString("grades");
                    lst.Add(course);
                }

                myreader.Close();

                conn.Close();
            }
            catch (MySqlException e)
            {

            }
            return lst;
        }
    }
}
