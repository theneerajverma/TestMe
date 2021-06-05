using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public string Name { get; set; }
        public int AppliedAfter { get; set; }
        public char AppliedOn { get; set; }
        public int PromotionalAmount { get; set; }
        public PromotionType PromotionalType { get; set; }
        public char ClubbedWith { get; set; }
    }

    public enum PromotionType
    {
        Normal,
        Clubbed
    }
}