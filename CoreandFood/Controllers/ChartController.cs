using CoreandFood.Data;
using CoreandFood.Data.Models;
using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Controllers
{
    public class ChartController : Controller
    {
        FoodRepository fr = new FoodRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Chart> ProList()
        {
            List<Chart> cs = new List<Chart>();
            using(Context c = new Context())
            {
                cs = c.Foods.Select(x => new Chart
                {
                    Name = x.Name,
                    Value = x.Stock
                }).ToList();
            }
            return cs;
        }
        public IActionResult Statistics()
        {
            using (Context c = new Context())
            {
                ViewBag.d1 =c.Foods.Count().ToString();
                ViewBag.d2 =c.Categories.Count();
                ViewBag.d3 =c.Foods.Where(x=>x.Category.CategoryName=="Fruit").Sum(x=>x.Stock);
                ViewBag.d4 = c.Foods.Where(x => x.Category.CategoryName == "Vegetables").Sum(x => x.Stock);
                ViewBag.d5 = c.Foods.Sum(x => x.Stock);
                var max =c.Foods.Max(x=>x.Stock);
                ViewBag.d6 = c.Foods.Where(x => x.Stock == max).Select(y => y.Name).FirstOrDefault();
                var value = (from x in c.Foods.AsEnumerable()
                             group x by x.CategoryID into g
                             select new Chart
                             {
                                 Name = g.Key.ToString(),
                                 Value = g.Sum(p => p.Stock)
                             }).ToList();
                var max2 = value.Max(X => X.Value);
                var deger = value.Where(x => x.Value == max2).Select(x => x.Name).FirstOrDefault();
                var deger2 = c.Categories.Where(x => x.CategoryID == Convert.ToInt32(deger)).Select(x => x.CategoryName).FirstOrDefault();
                //var deger2 = c.Foods.GroupBy(p => p.CategoryID).OrderByDescending(p => p.Sum(x => x.Stock)).Take(1).

                //Select(p => new Chart
                //{
                //    Name = p.Key.ToString(),
                //    Value = p.Sum(x => x.Stock)
                //});

                //var deger3 =deger2.Select(x => x.Name).FirstOrDefault();
                //var deger4 = c.Categories.Where(x => x.CategoryID == Convert.ToInt32(deger3)).Select(x => x.CategoryName).FirstOrDefault();
                ViewBag.d7 = deger2;
                var s =c.Foods.Average(x=>x.Price);
                ViewBag.d8 = s.ToString().Substring(0, 6);
            }
            
            return View();
        }

    }
}
