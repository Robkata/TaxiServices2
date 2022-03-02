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
        public DbSet<ExpressTaxi.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
    }
}
