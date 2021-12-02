using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//this line may be red -> in Solution Explorer(right) right click on References-Add Reference
//choose Browse from the left part and click Browse and select the MySql.Data.dll file
//you can download it from https://dev.mysql.com/downloads/connector/net/
using MySql.Data.MySqlClient;
using asp_temp.Models;
namespace asp_temp.DataAbstractionLayer
{
    public class DAL
    {
        public MySqlConnection ConnectToDataBase()
        {

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=dorisuca;pwd=12345;database=exam;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;

            return conn;
        }

        internal List<Child> GetChildrenByParentName(string name)
        {
            List<Child> children = new List<Child>();
            MySqlConnection conn = ConnectToDataBase();
            conn.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "select id from a where name='" + name + "'";
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32("id");
                reader.Close();
                MySqlCommand command2 = new MySqlCommand();
                command2.Connection = conn;
                command2.CommandText = "select * from b where aid='" + id + "'";
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    Child child = new Child();
                    child.id = reader2.GetInt32("id");
                    child.name = reader2.GetString("name");
                    child.parentid = reader2.GetInt32("aid");
                    children.Add(child);
                }
            }
            return children;
        }
    }
}