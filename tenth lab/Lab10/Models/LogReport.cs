using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class LogReport
    {
        private int id;
        private int user_id;
        private string type;
        private string severity;
        private string date;

        public int Id { get => id; set => id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Type { get => type; set => type = value; }
        public string Severity { get => severity; set => severity = value; }
        public string Date { get => date; set => date = value; }
    }
}