using Quarterly_Sales_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Quarterly_Sales_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Grace",
                    LastName = "Hopper",
                    DOB = new DateTime(1996, 12, 9),
                    DateOfHiring = new DateTime(2024, 01, 01),
                    ManagerName = "Tim Cook"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Tim",
                    LastName = "Cook",
                    DOB = new DateTime(1998, 12, 10),
                    DateOfHiring = new DateTime(2022, 09, 07),
                    ManagerName = ""
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Jhon",
                    LastName = "Rock",
                    DOB = new DateTime(1999, 11, 8),
                    DateOfHiring = new DateTime(2021, 08, 04),
                    ManagerName = "Tim Cook"
                });

            modelBuilder.Entity<Sales>().HasData(
              new Sales
              {
                  Id = 1,
                  Quarter = 1,
                  Year = 2021,
                  Amount = 100000,
                  EmployeeName = "Tim Cook"
              },
               new Sales
               {
                   Id = 2,
                   Quarter = 3,
                   Year = 2022,
                   Amount = 100000,
                   EmployeeName = "Tim Cook"
               },
                new Sales
                {
                    Id = 3,
                    Quarter = 4,
                    Year = 2019,
                    Amount = 100000,
                    EmployeeName = "Tim Cook"
                }

              );
        }
    }
}
