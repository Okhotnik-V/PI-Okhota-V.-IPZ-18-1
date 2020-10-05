using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_dealership.Models
{
    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }
        // ім’я і прізвище покупця 
        public string Person { get; set; } 
        // адреса покупця
        public string Address { get; set; } 
        // ID книги
        public int BookId { get; set; } 
        // дата покупки 
        public DateTime Date { get; set; }
    }
}