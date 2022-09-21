using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=89.252.137.91;Database=skyticar_skyapp;Uid=skyticar_kutluhan;Pwd=Sky2021.;",
            new MySqlServerVersion(new Version()));
            //MySql connectionString
        }

        public DbSet<Order> orders { get; set; }
    }
}