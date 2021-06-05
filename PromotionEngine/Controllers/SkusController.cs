using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PromotionEngine.Models;

namespace PromotionEngine.Controllers
{
    public class SkusController : Controller
    {
        private static List<Sku> skus = new List<Sku>()
        {
            new Sku() { SkuId = 'A', Price = 50 },
            new Sku() { SkuId = 'B', Price = 30 },
            new Sku() { SkuId = 'C', Price = 20 },
            new Sku() { SkuId = 'D', Price = 15 }
        };
        private static List<Promotion> promotion = new List<Promotion>()
        {
            new Promotion() { Name = "ThreeOfA", AppliedAfter = 3, AppliedOn = 'A', PromotionalAmount = 130, PromotionalType= PromotionType.Normal },
            new Promotion() { Name = "TwoOfB", AppliedAfter = 2, AppliedOn = 'B', PromotionalAmount = 45, PromotionalType= PromotionType.Normal },
            new Promotion() { Name = "OneOfCAndD", AppliedAfter = 1, AppliedOn = 'C', PromotionalAmount = 30 , PromotionalType= PromotionType.Clubbed, ClubbedWith='D'},
        };
        public ActionResult Create()
        {
            List<SkuVM> s = skus.Select(x => new SkuVM { SkuId = x.SkuId, Price = x.Price }).ToList();
            return View(s);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<SkuVM> skuVMs)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                for (int i = 0; i < promotion.Count; i++)
                {
                    for (int j = 0; j < skuVMs.Count; j++)
                    {
                        if (promotion[i].AppliedOn == skuVMs[j].SkuId)
                        {
                            if (promotion[i].PromotionalType == PromotionType.Normal)
                            {
                                if (skuVMs[j].Quantity >= promotion[i].AppliedAfter)
                                {
                                    double temp = skuVMs[j].Quantity / promotion[i].AppliedAfter;
                                    amount += Convert.ToInt16(Math.Floor(temp)) * promotion[i].PromotionalAmount + (skuVMs[j].Quantity % promotion[i].AppliedAfter) * skuVMs[j].Price;
                                    break;
                                }
                                else
                                {
                                    amount += skuVMs[j].Quantity * skuVMs[j].Price;
                                    break;
                                }
                            }
                            else
                            {
                                if (skuVMs[j].Quantity >= promotion[i].AppliedAfter)
                                {
                                    char club = promotion[i].ClubbedWith;
                                    int quantityCurrent = skuVMs[j].Quantity;
                                    int quantityNext = 0;
                                    int priceNext = 0;
                                    for (int k = 0; k < skuVMs.Count; k++)
                                    {
                                        if (skuVMs[k].SkuId == club)
                                        {
                                            quantityNext = skuVMs[k].Quantity;
                                            priceNext = skuVMs[k].Price;
                                        }
                                    }
                                    if (quantityCurrent > quantityNext)
                                    {
                                        amount += (quantityNext * promotion[i].PromotionalAmount) + (quantityCurrent - quantityNext) * skuVMs[j].Price;
                                    }
                                    else if (quantityCurrent < quantityNext)
                                    {
                                        amount += (quantityCurrent * promotion[i].PromotionalAmount) + (quantityNext - quantityCurrent) * priceNext;
                                    }
                                    else
                                    {
                                        amount += quantityCurrent * promotion[i].PromotionalAmount;
                                    }
                                }
                                else
                                {
                                    amount += skuVMs[j].Quantity * skuVMs[j].Price;
                                    break;
                                }
                            }
                        }
                    }
                }
                TempData["FinalAmount"] = "Final Price " + Convert.ToString(amount);
                List<SkuVM> s = skus.Select(x => new SkuVM { SkuId = x.SkuId, Price = x.Price }).ToList();
                return View(s);
            }
            return View(skus);
        }
    }
}
