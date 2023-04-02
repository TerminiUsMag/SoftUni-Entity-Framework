using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelations
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RelationsDemo;User Id=sa;Password=None124578;MultipleActiveResultSets=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>()
            //    .HasKey(c => c.CarPrimaryId);// Sets primary key of table
            //modelBuilder.Entity<Car>()
            //    .Property(c => c.CarPrimaryId)// Sets column name in table
            //    .HasColumnName("ID");

            //modelBuilder.Entity<Car>()                             //Way to create Composite Primary Key (Only Using Fluent API)
            //    .HasKey(c => new { c.Region, c.LicensePlate });
        }
    }
}
