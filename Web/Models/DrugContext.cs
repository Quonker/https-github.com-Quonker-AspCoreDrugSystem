using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class DrugContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DrugContext(DbContextOptions<DrugContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            Company medtronic = new Company { Id = 1, Name = "Medtronic" };
            Company abbott = new Company { Id = 2, Name = "Abbott" };
            Company cw = new Company { Id = 3, Name = "Cardinal Health" };
            Company baxter = new Company { Id = 4, Name = "Baxter " };
            Company romfarm = new Company { Id = 5, Name = "Romfarm " };


            Drug drug1 = new Drug { Id = 1, Tradename = "Slezin", CompanyId = 5, Price = 2.70M };
            Drug drug2 = new Drug { Id = 2, Tradename = "Almagel", CompanyId = 1, Price = 3.45M };
            Drug drug3 = new Drug { Id = 3, Tradename = "Colchicine", CompanyId = 2, Price = 13.99M };
            
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            modelBuilder.Entity<Company>().HasData(new Company[] { medtronic, cw, abbott, baxter, romfarm });
            modelBuilder.Entity<Drug>().HasData(new Drug[] { drug1, drug2, drug3 });
            base.OnModelCreating(modelBuilder);

        }
    }
}
