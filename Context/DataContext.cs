using Microsoft.EntityFrameworkCore;
using MyCompany_BackEnd.Models;

namespace MyCompany_BackEnd.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) :base(options){ }
         
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> AllEmployees { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(c => c.department);
        }
    }
}
