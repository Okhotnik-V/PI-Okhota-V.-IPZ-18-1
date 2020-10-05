using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Car_dealership.Models
{
    public class CarDbInitializer:DropCreateDatabaseAlways<CasrContext>
    {
        protected override void Seed(CasrContext db)
        {
            db.Cars.Add(new Сars { Name = "X5", Brand = "BMW", Price = 78968 });
            db.Cars.Add(new Сars { Name = "C Class", Brand = "Mercedes Benz", Price = 90000 });
            db.Cars.Add(new Сars { Name = "Vivaro", Brand = "Opel", Price = 45000 });
            base.Seed(db);

        }

    }
}