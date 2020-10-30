using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public string PurchaseDate { get; set; }
        public string CarId { get; set; }
        public int ShopId { get; set; }
    }
}