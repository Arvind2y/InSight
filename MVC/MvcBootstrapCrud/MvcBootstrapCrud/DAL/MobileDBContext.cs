using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcBootstrapCrud.Models;

namespace MvcBootstrapCrud.DAL
{
    public class MobileDBContext : DbContext
    {        
        public MobileDBContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<MobileDBContext>
                (new DropCreateDatabaseIfModelChanges<MobileDBContext>());
        }
        
        public DbSet<Phone> Phones { get; set; }

    }
}