using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PuzzleShop.Domain.Entities.Auth;
// ReSharper disable All

namespace PuzzleShop.Api.Helpers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role("admin"));
            }
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new Role("moderator"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role("user"));
            }
            if (await roleManager.FindByNameAsync("banished") == null)
            {
                await roleManager.CreateAsync(new Role("banished"));
            }

            var user = await userManager.FindByNameAsync("administrator");
            if (user == null)
            {
                var adminUser = new User
                {
                    FirstName = "Vitaly", LastName = "Glinka", Email = "example@mail.com",
                    Address = "address", BirthDate = new DateTime(1998, 2, 17), UserName = "administrator"
                };
                var result = await userManager.CreateAsync(adminUser, "Admin12345!");
                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(adminUser, 
                        new List<string> {"admin", "moderator", "user"});
                }
            }
        }
    }
}