using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}