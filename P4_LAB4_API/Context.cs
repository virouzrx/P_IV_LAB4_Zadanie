using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace P4_LAB4_API
{
    public class FootballContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Coaches> Coaches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FootbalDB;Trusted_Connection=True;"); //trzeba bylo osobno doinstalowac .UseSqlServer
        }
 
    }
}