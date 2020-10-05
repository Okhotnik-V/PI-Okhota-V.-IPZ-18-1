using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_dealership.Models
{
    public class Сars
    {
        // ID автомобіля 
        public int Id { get; set; } 
        // назва автомобіля 
        public string Name { get; set; } 
        // марка автомобіля
        public string Brand { get; set; } 
        // ціна 
        public int Price { get; set; }
    }
}