using CoreandFood.Data;
using CoreandFood.Data.Models;
using CoreandFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository cr = new CategoryRepository();
        Context c = new Context(); 
      
        public IActionResult Index()
        {
            return View(cr.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            p.Status = true;
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            cr.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = cr.TGet(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            p.Status = true;
            cr.TUpdate(p);
            return RedirectToActionPermanent("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var p = cr.TGet(id);
            p.Status = false;
            cr.TUpdate(p);
            return RedirectToActionPermanent("Index");
        }

    }
}
