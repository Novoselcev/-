﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magistral40
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class magistralEntities : DbContext
    {
        public magistralEntities()
            : base("name=u7716449_magistralEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Messager> Messager { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
    }
}