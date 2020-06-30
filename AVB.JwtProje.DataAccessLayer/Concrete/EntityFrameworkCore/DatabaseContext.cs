using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AVB.JwtProje.DataAccessLayer.Concrete.Mapping;
using AVB.JwtProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AVB.JwtProje.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KJAVELINPC\\SQLEXPRESS;Database=JwtDatabase;User Id=kjavelin;Password=85213589cz;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles{ get; set; }
        

    }
}
