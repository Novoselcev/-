using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Magistral40.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        public string Context { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public string UrlDescriptImg { get; set; }
        public Int32 Position { get; set; }
        public Boolean Visible { get; set; }
        public String Price { get; set; }
        public String URL { get; set; }
    }
}