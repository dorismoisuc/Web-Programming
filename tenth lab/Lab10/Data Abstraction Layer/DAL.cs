using Lab8.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Data_Abstraction_Layer
{
    public class DAL
    {
        
        public MySqlConnection getConnection()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=dorisuca;pwd=12345;database=dorisuca;";
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
                cmd.CommandText = "select * from users where username='" + user + "'and password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    users.Add(myreader.GetString("username"));
                }
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            return users.Count == 1;

        }

        internal List<LogReport> GetReportsOnPage(int pageNo, int pageSize, int totalSize)
        {
            int offset = pageNo * pageSize;
            int totalPages = (int) Math.Ceiling((double) totalSize / pageSize);
            List<LogReport> reports = new List<LogReport>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from logreport limit " + offset + ", " + pageSize + ";";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    LogReport report = new LogReport();
                    report.Id = myreader.GetInt32("id");
                    report.User_id = myreader.GetInt32("user_id");
                    report.Type = myreader.GetString("type");
                    report.Severity = myreader.GetString("severity");
                    report.Date = myreader.GetString("date_posted");
                    reports.Add(report);
                }
                myreader.Close();

                conn.Close();
            }
            catch(MySqlException e)
            {

            }
            return reports;
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

            }
            return report;
        }

        internal List<string> GetAllSeverities(string user)
        {
            List<string> severities = new List<string>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select distinct r.severity from logreport r inner join users u on r.user_id=u.id where u.username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    severities.Add(myreader.GetString("severity"));
                    System.Diagnostics.Debug.WriteLine(myreader.GetString("severity"));
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return severities;
        }

        public List<string> GetAllTypes(string user)
        {
            List<string> types = new List<string>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select distinct r.type from logreport r inner join users u on r.user_id=u.id where u.username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    types.Add(myreader.GetString("type"));
                    System.Diagnostics.Debug.WriteLine(myreader.GetString("type"));
                }
                myreader.Close();
                conn.Close();
            }
            catch(MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return types;
        }

        internal List<LogReport> GetLogReportsOfUser(string user)
        {
            List<LogReport> slist = new List<LogReport>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandText = "select r.id, r.user_id, r.type, r.severity, r.date_posted from logreport r inner join users u on u.id=r.user_id where u.username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    LogReport report = new LogReport();
                    report.Id = myreader.GetInt32("id");
                    report.User_id = myreader.GetInt32("user_id");
                    report.Type = myreader.GetString("type");
                    report.Severity = myreader.GetString("severity");
                    report.Date = myreader.GetString("date_posted");
                    slist.Add(report);
                }
                myreader.Close();
                
                conn.Close();
            }
            catch (MySqlException ex)
            {
                
                Console.Write(ex.Message);
            }
            return slist;
        }

        public List<LogReport> GetLogReports()
        {         
            List<LogReport> slist = new List<LogReport>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from logreport" ;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    LogReport report = new LogReport();
                    report.Id = myreader.GetInt32("id");
                    report.User_id = myreader.GetInt32("user_id");
                    report.Type = myreader.GetString("type");
                    report.Severity = myreader.GetString("severity");
                    report.Date = myreader.GetString("date_posted");
                    slist.Add(report);
                }
                myreader.Close();
           
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("here");
                Console.Write(ex.Message);
            }
            return slist;
        }

        public bool AddLogReport(LogReport log)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = getConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO logreport(user_id, type, severity, date_posted) VALUES (" +
                log.User_id + ", '" + log.Type + "', '" + log.Severity + "', '" + log.Date + "');";  
            int cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt==1;
        }

        public bool DeleteLogReport(int id)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = getConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM logreport WHERE id=" + id;
            int cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt == 1;
        }

        public List<LogReport> GetReportsOfType(string type, string user)
        {
            List<LogReport> slist = new List<LogReport>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select r.id, r.user_id, r.type, r.severity, r.date_posted from logreport r inner join users u on u.id=r.user_id where type='" + type + "' and u.username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    LogReport report = new LogReport();
                    report.Id = myreader.GetInt32("id");
                    report.User_id = myreader.GetInt32("user_id");
                    report.Type = myreader.GetString("type");
                    report.Severity = myreader.GetString("severity");
                    report.Date = myreader.GetString("date_posted");
                    slist.Add(report);
                }
                myreader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return slist;
        }

        public List<LogReport> GetReportsOfSeverity(string severity, string user)
        {
            List<LogReport> slist = new List<LogReport>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select r.id, r.user_id, r.type, r.severity, r.date_posted from logreport r inner join users u on u.id=r.user_id where severity='" + severity + "' and u.username='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    LogReport report = new LogReport();
                    report.Id = myreader.GetInt32("id");
                    report.User_id = myreader.GetInt32("user_id");
                    report.Type = myreader.GetString("type");
                    report.Severity = myreader.GetString("severity");
                    report.Date = myreader.GetString("date_posted");
                    slist.Add(report);
                }
                myreader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;
        }
    }
}