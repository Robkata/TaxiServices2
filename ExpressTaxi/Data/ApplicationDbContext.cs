using ExpressTaxi.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ExpressTaxi.Models;

namespace ExpressTaxi.Data
{
    public class ApplicationDbContext : IdentityDbContext<TaxiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
       // public DbSet<ExpressTaxi.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
        //public DbSet<ExpressTaxi.Models.AdminAllViewModel> AdminAllViewModel { get; set; }
        //public DbSet<ExpressTaxi.Models.ArticleCreateViewModel> ArticleCreateViewModel { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Taxi> Taxies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ExpressTaxi.Models.TaxiCreateViewModel> TaxiCreateViewModel { get; set; }
    }
}
