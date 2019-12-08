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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeDAL.GetEmployeeById(id);
            if (employee == null)
            {
                NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Employee employee)
        {
            if (id == null)
            {
                return NotFound();
            }

         

            if (ModelState.IsValid)
            {
                employeeDAL.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var employee = employeeDAL.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

    }

   
}