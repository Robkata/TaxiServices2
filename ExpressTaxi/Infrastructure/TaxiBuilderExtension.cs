using ExpressTaxi.Data;
using ExpressTaxi.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Infrastructure
{
    public static class TaxiBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedReservations(data);

            return app;
        }

        private static void SeedReservations(ApplicationDbContext data)
        {
            if (data.Reservations.Any())
            {
                return;
            }
            data.Reservations.AddRange(new[]
            {
                new Reservation { Name = "Англоговорящ шофьор"},
                new Reservation { Name = "Плащане с карта" },
                new Reservation { Name = "Много багаж" }
            });
            data.SaveChanges();
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<TaxiUser>>();

            if(await userManager.FindByNameAsync("admin") == null)
            {
                TaxiUser user = new TaxiUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.FirstName = "Admin";
                user.LastName = "Adminov";
                user.PhoneNumber = "0888888888";
                user.Address = "Pernik";
                var result = await userManager.CreateAsync(user, "123!@#qweQWE");

                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach(var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
