using DataAccess.Concrete.EfCore;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class DataContext:DbContext
    {
        string path =""; 
        public DbSet<Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ersen\\Desktop\\deneme3333\\denemeeee\\DataAccess\\DataContext.db");
        }


    }
}
