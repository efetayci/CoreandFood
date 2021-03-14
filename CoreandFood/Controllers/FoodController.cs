using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreandFood.Data.Models;
using CoreandFood.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreandFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository fr = new FoodRepository();
        public IActionResult Index(int page=1)
        {   
            return View(fr.TList("Category").ToPagedList(page,4));
        }

        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> deger = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.ct = deger;
            return View();
        }

        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> deger = (from x in c.Categories.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();
                ViewBag.ct = deger;
                return View("FoodAdd");
            }
            fr.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult FoodDelete(int id)
        {
            fr.TDelete(new Food { FoodID=id});
            return RedirectToAction("Index");
        }
        public IActionResult FoodList()
        {
            return View(fr.TList("Category"));
        }

    }
}

