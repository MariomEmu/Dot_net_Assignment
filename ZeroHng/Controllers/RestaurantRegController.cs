using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHng.EF;

namespace ZeroHng.Controllers
{
    public class RestaurantRegController : Controller
    {
        // GET: RestaurantReg

        public ActionResult Registration(int id = 0)
        {
            Restaurant item = new Restaurant();
            return View(item);
        }
        [HttpPost]
        public ActionResult Registration(Restaurant item, FormCollection form)
        {
            if (item.Password == form["Confirm_Password"])
            {
                using (var dataa = new Zero_HungerEntities2())
                {
                    if (dataa.Restaurants.Any(x => x.Name == item.Name))
                    {
                        ViewBag.DuplicateMessage = "Restaurant Name Already Exists.";
                        return View("Registration", item);
                    }
                    else
                    {
                        dataa.Restaurants.Add(item);
                        dataa.SaveChanges();
                    }
                     ModelState.Clear();
                    ViewBag.SuccessMessage = "Save Successfully";
                    return View("Registration", new Restaurant());
                }
            }
            else
            {
                ViewBag.MismatchPasswor = "Password not matching";
                return View(item);
            }
        }

    }
}