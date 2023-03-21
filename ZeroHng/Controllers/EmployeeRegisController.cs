using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHng.Ef;

namespace ZeroHng.Controllers
{
    public class EmployeeRegisController : Controller
    {
        // GET: EmployeeRegis
        public ActionResult Registration1(int id = 0)
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Registration1(Employee employee)
        {
             using( db data = new db())
            {
                if(data.Employees.Any(x => x.Name==employee.Name))
                {
                    ViewBag.DuplicateMessage = "Employee Name Already Exists.";
                    return View("Registration1", employee);
                }
                else
                {
                    data.Employees.Add(employee);
                    data.SaveChanges();
                }
               // ModelState.Clear();
                ViewBag.SuccessMessage = "Save Successfully";
                return View("Registration1", new Employee());
            }
        }
    }
}