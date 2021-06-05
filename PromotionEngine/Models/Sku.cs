using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionEngine.Models
{
    public class Sku
    {
        public char SkuId { get; set; }
        public int Price { get; set; }
    }
    public class SkuVM
    {
        public char SkuId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

}