using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Magistral40.Models
{
    public class MagistralContext : DbContext
    {
        public MagistralContext() : base("MagConnection")
        { }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Messager> Message { get; set; }

        public DbSet<Articles> Articl { get; set; }

    }
}