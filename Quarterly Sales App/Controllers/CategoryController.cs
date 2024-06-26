﻿using Quarterly_Sales_App.Data;
using Quarterly_Sales_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarterly_Sales_App.ViewModel;
using Microsoft.IdentityModel.Tokens;

namespace Quarterly_Sales_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext appDbContext) {
           _context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.employees.ToListAsync();
            var managers = employees.Select(e => new ManagersDropDown
            {
                Id = e.FirstName + " " + e.LastName,
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            ViewBag.Managers = managers;

            var distinctValues = await _context.Sales
                                .Select(x => x.Year)
                                .Distinct()
                                .OrderByDescending(year => year)
                                .ToListAsync();
            ViewBag.DistinctYears = distinctValues;

            var QuarterList = await _context.Sales
                              .Select (x => x.Quarter)
                              .Distinct()
                              .OrderByDescending(quarter => quarter)
                              .ToListAsync();
            ViewBag.QuarterList = QuarterList;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string? managerName, int? year, int? quarter)
        {
            IQueryable<Sales> query = _context.Sales;

            if (!managerName.IsNullOrEmpty())
            {
                query = query.Where(x => x.EmployeeName == managerName);
            }

            if (year.HasValue && year != 0)
            {
                query = query.Where(x => x.Year == year);
            }
            if (quarter.HasValue && quarter != 0) 
            {
                query = query.Where(x => x.Quarter == quarter);
            }
            var response = await query.ToListAsync();

            return Json(response);
        }

        public async Task<IActionResult> Create()
        {
            var employees = await _context.employees.ToListAsync();

            var managers = employees.Select(e => new ManagersDropDown
            {
                Id = e.FirstName + " " + e.LastName,
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            ViewBag.Managers = managers;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if(emp.FirstName == emp.LastName)
                ModelState.AddModelError("FirstName" , "First Name and Last Name can not be same.");
            
            var employees = await _context.employees.ToListAsync();
            var managers = employees.Select(e => new ManagersDropDown
            {
                Id = e.FirstName + " " + e.LastName,
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            ViewBag.Managers = managers;

            string empName = emp.FirstName.Trim()+" "+ emp.LastName.Trim();
            if(empName == emp.ManagerName)
                ModelState.AddModelError("ManagerName", "Manager And Employee Can't Be Same.");
            
            var check = await _context.employees.FirstOrDefaultAsync(x =>
                        x.FirstName == emp.FirstName &&
                        x.LastName == emp.LastName &&
                        x.DOB.Date == emp.DOB.Date
                        );

            if (check != null)
                ModelState.AddModelError("DOB", $"{check.FirstName+ " " + check.LastName} with DOB({check.DOB}) is already present in database.");
            
            if (ModelState.IsValid)
            {
                await _context.employees.AddAsync(emp);
                _context.SaveChanges();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index", "Category");
            }
            TempData["error"] = "Error creating Employee";
            return View();
        }

        public async Task<IActionResult> AddSales()
        {
            var employees = await _context.employees.ToListAsync();
            var managers = employees.Select(e => new ManagersDropDown
            {
                Id = e.FirstName + " " + e.LastName,
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            ViewBag.Managers = managers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSales(Sales sale)
        {
            var employees = await _context.employees.ToListAsync();
            var managers = employees.Select(e => new ManagersDropDown
            {
                Id = e.FirstName + " " + e.LastName,
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            var check = await _context.Sales.FirstOrDefaultAsync(x=>x.EmployeeName == sale.EmployeeName);
            if (check != null)
            {
                if(check.Year == sale.Year && check.Quarter == sale.Quarter)
                {
                    ModelState.AddModelError("EmployeeName", $"Sales for {check.EmployeeName} for year {check.Year} Q{check.Quarter} " +
                        $"is already available in database.");
                }
            }

            ViewBag.Managers = managers;

            if (ModelState.IsValid)
            {

                await _context.Sales.AddAsync(sale);
                _context.SaveChanges();
                TempData["success"] = "Sale added successfully";
                return RedirectToAction("Index", "Category");
            }
            TempData["error"] = "Error Adding Sale";
            return View();
        }
    }
}
