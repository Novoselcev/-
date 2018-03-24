using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magistral40.Models
{
    [Table("Admin", Schema = "u7716449_magistral")]
    public class Admin
    {
        public Int32 Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime Date_vhod { get; set; }
    }
}