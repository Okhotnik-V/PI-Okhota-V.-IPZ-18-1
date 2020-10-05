using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Car_dealership.Models
{
    public class CasrContext : DbContext
    {
        public DbSet<Сars> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}