using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using asp_app.Models;

namespace asp_app.DataAbstractionLayer
{
    public class DAL
    {
        public MySqlConnection getConnection()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;pwd=;database=courses;";
            return new MySqlConnection(myConnectionString);
        }

        public bool login(string user)
        {
            List<String> users = new List<String>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from persons where name='" + user + "' and role='professor'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    users.Add(myreader.GetString("name"));
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

        public int GetUserIdOfUser(string user)
        {
            int report = 0;
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select id from persons where name='" + user + "'";
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

        public String getPersonName(String id)
        {
            String report = "";
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select name from persons where id='" + id + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    report = myreader.GetString("name");
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

        public List<String> GetParticipantsNames(string coursename)
        {
            List<String> names = new List<String>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from courses where coursename='" + coursename + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    String participantsStr = myreader.GetString("participants");
                    String[] strIds = participantsStr.Split(',');
                    foreach (string id in strIds)
                    {
                        names.Add(getPersonName(id));
                    }
                    //int result = Int32.Parse(input);
                }
                conn.Close();
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return names;
        }

        public List<Course> GetStudentCourses(int sid)
        {
            List<Course> courses = new List<Course>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from courses";
                MySqlDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    String participantsStr = myreader.GetString("participants");
                    String[] strIds = participantsStr.Split(',');
                    foreach (string id in strIds)
                    {
                        if(Int32.Parse(id) == sid)
                        {
                            Course c = new Course();
                            c.Id = myreader.GetInt32("id");
                            c.ProfessorId = myreader.GetInt32("professorid");
                            c.CourseName = myreader.GetString("coursename");
                            c.Participants = myreader.GetString("participants");
                            c.Grades = myreader.GetString("grades");
                            courses.Add(c);
                            break;
                        }
                        
                    }
                    //int result = Int32.Parse(input);
                }
                conn.Close();
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return courses;
        }

        public Course GetCourse(int cid)
        {
            Course c = new Course();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from courses where id='" + cid + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                { 
                    c.Id = myreader.GetInt32("id");
                    c.ProfessorId = myreader.GetInt32("professorid");
                    c.CourseName = myreader.GetString("coursename");
                    c.Participants = myreader.GetString("participants");
                    c.Grades = myreader.GetString("grades");
                }
                conn.Close();
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return c;
        }

        public void updateCourse(Course c)
        {
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE courses SET professorid='" + c.ProfessorId +
                                              "',coursename='" + c.CourseName +
                                            "',participants='" + c.Participants +
                                           "',grades='" + c.Grades +
                                        "' WHERE id='" + c.Id + "';";
                cmd.ExecuteNonQuery();
                conn.Close();
              
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}