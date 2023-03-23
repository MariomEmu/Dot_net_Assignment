using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHng.EF;

namespace ZeroHng.Controllers
{
    public class HomeController : Controller
    {
        Zero_HungerEntities2 _context = new Zero_HungerEntities2();
        public ActionResult Index()
        {

            var listofData = _context.Foods.ToList();
            return View(listofData);
        }
        [HttpGet] 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Create(Food model) 
        {
            _context.Foods.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet] 
        public ActionResult Edit(int id) 
        {
            var data = _context.Foods.Where(x => x.FoodId == id).FirstOrDefault();
            return View(data);
        
        }
        [HttpPost]
        public ActionResult Edit(Food Model)
        {
        var data = _context.Foods.Where(x => x.FoodId == Model.FoodId).FirstOrDefault();
            if(data!=null)
            {
                data.Id = Model.Id;
                data.Name = Model.Name;
                data.Quantity = Model.Quantity;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = _context.Foods.Where(x => x.FoodId == id).FirstOrDefault();
            return View(data);

        }
        public ActionResult Delete(int id)
        {
            var data = _context.Foods.Where(x => x.FoodId == id).FirstOrDefault();
            _context.Foods.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Recorde Delete Successfully";
            return RedirectToAction("Index");   
        }









        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}