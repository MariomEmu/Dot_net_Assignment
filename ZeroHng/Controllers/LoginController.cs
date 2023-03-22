using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHng.EF;

namespace ZeroHng.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult EmployeeLogin(int id = 0)
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult EmployeeLogin(Employee employee, FormCollection form)
        {
            using (var data1 = new Zero_HungerEntities2())
            {
                if (data1.Employees.Any(x => x.Name == employee.Name && x.Password==employee.Password))
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.DuplicateMessage = "Employee Name Already Exists.";
                    return View("EmployeeLogin", employee);
                    
                }
               
            }
        }


    }

}
    
    