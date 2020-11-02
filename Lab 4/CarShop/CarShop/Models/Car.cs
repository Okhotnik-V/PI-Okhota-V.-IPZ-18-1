using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Car
    {
      
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Prise { get; set; }
            public int? SalonId { get; set; }
            public Salon Salon { get; set; }
        

    }
}