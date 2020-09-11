using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAB4_API
{
    public class Context : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Advanced> Advanced { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=APIDATABASE;Trusted_Connection=True;");
        }
    }
}
