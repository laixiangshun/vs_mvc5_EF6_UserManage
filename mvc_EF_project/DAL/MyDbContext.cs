using mvc_EF_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace mvc_EF_project.DAL
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
            : base("MyDbContext")
        {

        }
        public DbSet<BookInfo> BookInfos { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}