using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class Car
    {

        [ScaffoldColumn(false)]
            public virtual int Id { get; set; }
            [Display(Name = "Марка та модель")]
          
             public virtual string Name { get; set; }
            [Display(Name = "Рік виробництва")]
           
            public virtual int Age { get; set; }
            [Display(Name = "Ціна")]
            
             public virtual string Prise { get; set; }
           
          
            public virtual int? SalonId { get; set; }
            
            public Salon Salon { get; set; }     
    }

}

