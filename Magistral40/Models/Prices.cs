using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magistral40.Models
{
    [Table("Prices", Schema = "u7716449_vxod")]
    public class Prices
    {
        public Int32 SortIndex { get; set; }
        public Int32 id { get; set; }
        [Display(Name = "Наименование")]
        public String Name { get; set; }
        [Display(Name = "Единица измерения")]
        public String IE { get; set; }
        public String classM { get; set; }
        public String URL { get; set; }
        public String Group_Name { get; set; }
        public String Group_Name_Main { get; set; }

       [Display(Name = "Цена, руб.*")]
        public float Price { get; set; }
        
    }
}