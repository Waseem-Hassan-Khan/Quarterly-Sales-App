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
                },
            new Employee
            {
                Id = 4,
                FirstName = "Alan",
                LastName = "Turing",
                DOB = new DateTime(1912, 6, 23),
                DateOfHiring = new DateTime(1936, 7, 1),
                ManagerName = "Grace Hopper"
            },
    new Employee
    {
        Id = 5,
        FirstName = "Ada",
        LastName = "Lovelace",
        DOB = new DateTime(1815, 12, 10),
        DateOfHiring = new DateTime(1837, 7, 1),
        ManagerName = "Grace Hopper"
    },
    new Employee
    {
        Id = 6,
        FirstName = "Nikola",
        LastName = "Tesla",
        DOB = new DateTime(1856, 7, 10),
        DateOfHiring = new DateTime(1884, 6, 1),
        ManagerName = "Grace Hopper"
    },
    new Employee
    {
        Id = 7,
        FirstName = "Marie",
        LastName = "Curie",
        DOB = new DateTime(1867, 11, 7),
        DateOfHiring = new DateTime(1897, 4, 1),
        ManagerName = "Grace Hopper"
    },
    new Employee
    {
        Id = 8,
        FirstName = "Albert",
        LastName = "Einstein",
        DOB = new DateTime(1879, 3, 14),
        DateOfHiring = new DateTime(1902, 5, 1),
        ManagerName = "Grace Hopper"
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
                },
new Sales
{
    Id = 4,
    Quarter = 3,
    Year = 2022,
    Amount = 100000,
    EmployeeName = "Grace Hopper"
},

new Sales
{
    Id = 5,
    Quarter = 4,
    Year = 2019,
    Amount = 100000,
    EmployeeName = "Tim Cook"
},
new Sales
{
    Id = 6,
    Quarter = 1,
    Year = 2020,
    Amount = 100000,
    EmployeeName = "Tim Cook"
},
new Sales
{
    Id = 7,
    Quarter = 4,
    Year = 2023,
    Amount = 80000 * 1000,
    EmployeeName = "Nikola Tesla"
}
,
new Sales
{
    Id = 8,
    Quarter = 4,
    Year = 2023,
    Amount = 80000 * 1000,
    EmployeeName = "Nikola Tesla"
},
new Sales
{
    Id = 9,
    Quarter = 3,
    Year = 2023,
    Amount = 80000 * 100,
    EmployeeName = "Nikola Tesla"
},
new Sales
{
    Id = 10,
    Quarter = 1,
    Year = 2024,
    Amount = 8700359,
    EmployeeName = "Nikola Tesla"
},
new Sales
{
    Id = 24,
    Quarter = 1,
    Year = 2021,
    Amount = 100000,
    EmployeeName = "Albert Einstein"
},
new Sales
{
    Id = 11,
    Quarter = 3,
    Year = 2022,
    Amount = 95000,
    EmployeeName = "Albert Einstein"
},
new Sales
{
    Id = 12,
    Quarter = 2,
    Year = 2023,
    Amount = 90000,
    EmployeeName = "Albert Einstein"
},
new Sales
{
    Id = 13,
    Quarter = 4,
    Year = 2024,
    Amount = 85000,
    EmployeeName = "Albert Einstein"
},
new Sales
{
    Id = 14,
    Quarter = 1,
    Year = 2025,
    Amount = 80000,
    EmployeeName = "Albert Einstein"
},
new Sales
{
    Id = 15,
    Quarter = 1,
    Year = 2021,
    Amount = 110000,
    EmployeeName = "Marie Curie"
},
new Sales
{
    Id = 16,
    Quarter = 2,
    Year = 2022,
    Amount = 105000,
    EmployeeName = "Marie Curie"
},
new Sales
{
    Id = 17,
    Quarter = 3,
    Year = 2023,
    Amount = 100000,
    EmployeeName = "Marie Curie"
},
new Sales
{
    Id = 18,
    Quarter = 4,
    Year = 2024,
    Amount = 95000,
    EmployeeName = "Marie Curie"
},
new Sales
{
    Id = 19,
    Quarter = 1,
    Year = 2021,
    Amount = 120000,
    EmployeeName = "Ada Lovelace"
},
new Sales
{
    Id = 20,
    Quarter = 2,
    Year = 2022,
    Amount = 115000,
    EmployeeName = "Ada Lovelace"
},
new Sales
{
    Id = 21,
    Quarter = 3,
    Year = 2023,
    Amount = 110000,
    EmployeeName = "Ada Lovelace"
},
new Sales
{
    Id = 22,
    Quarter = 4,
    Year = 2024,
    Amount = 105000,
    EmployeeName = "Ada Lovelace"
},
new Sales
{
    Id = 23,
    Quarter = 1,
    Year = 2025,
    Amount = 100000,
    EmployeeName = "Ada Lovelace"
}
              );
        }
    }
}
