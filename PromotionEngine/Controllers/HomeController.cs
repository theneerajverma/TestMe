using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromotionEngine.Controllers
{
    public class HomeController : Controller
    {
        // private static List<Sku> sku = new List<Sku>() { new Sku() { SkuId = 'A', Price = 50 }, new Sku() { SkuId = 'B', Price = 30 }, new Sku() { SkuId = 'C', Price = 20 }, new Sku() { SkuId = 'D', Price = 15 } };
        // private static List<Promotion> promotion = new List<Promotion>() { new Promotion() { Name = "ThreeOfA", AppliedAfter = 3, AppliedOn = 'A' }, new Promotion() { Name = "TwoOfB", AppliedAfter = 2, AppliedOn = 'B' }, new Promotion() { Name = "CAndD", AppliedAfter = 3, AppliedOn = 'A' } };
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}