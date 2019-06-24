using System;
using System.Collections.Generic;

namespace Models
{
    public class Promotion:Entity
    {
        public int Percentage { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<UserPromotion> UserPromotions { get; set; }
    }
}
