using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace forest_asp.Models
{
    public class Asset
    {
        private int id;
        private int userid;
        private string name;
        private string description;
        private int value;

        public int Id { get => id; set => id = value; }
        public int Userid { get => userid; set => userid = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Value { get => value; set => this.value = value; }
    }
}