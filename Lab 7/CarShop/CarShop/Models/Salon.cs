using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mist { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}