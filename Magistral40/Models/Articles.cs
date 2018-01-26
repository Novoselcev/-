using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magistral40.Models
{

    [Table("Articles", Schema = "u7716449_vxod")]
    public class Articles
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
        public String Menu { get; set; }
        public String Razdel { get; set; }
        public String URL { get; set; }
        public String Layout { get; set; }
        public String SmallDescript { get; set; }
        public DateTime Date { get; set; }
    }

    public class MenuTop {
        public string Header { get; set; }
        public string URL { get; set; }
    }
}