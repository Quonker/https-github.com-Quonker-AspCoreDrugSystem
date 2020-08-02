using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class DrugContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DrugContext(DbContextOptions<DrugContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            Company medtronic = new Company { Id = 1, Name = "Medtronic" };
            Company abbott = new Company { Id = 2, Name = "Abbott" };
            Company cw = new Company { Id = 3, Name = "Cardinal Health" };
            Company baxter = new Company { Id = 4, Name = "Baxter " };
            Company romfarm = new Company { Id = 5, Name = "Romfarm " };


            Drug drug1 = new Drug { Id = 1, Tradename = "Slezin", CompanyId = 5,  };
            Drug drug2 = new Drug { Id = 2, Tradename = "Almagel", CompanyId = 1,  };
            Drug drug3 = new Drug { Id = 3, Tradename = "Colchicine", CompanyId = 2,  };
            
        

            modelBuilder.Entity<Company>().HasData(new Company[] { medtronic, cw, abbott, baxter, romfarm });
            modelBuilder.Entity<Drug>().HasData(new Drug[] { drug1, drug2, drug3 });
            base.OnModelCreating(modelBuilder);

        }
    }
}
