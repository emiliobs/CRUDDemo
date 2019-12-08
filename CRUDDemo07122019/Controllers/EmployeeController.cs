using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDDemo07122019.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo07122019.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();

        public IActionResult Index()
        {
            var employeeList = new List<Employee>();
            employeeList = employeeDAL.GetAllEmployee().ToList();

            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View();
        }

    
    }

   
}