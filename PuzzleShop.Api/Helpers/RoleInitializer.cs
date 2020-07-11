using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PuzzleShop.Core.Entities.Auth;

// ReSharper disable All

namespace PuzzleShop.Api.Helpers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            if (await roleManager.FindByNameAsync(AuthorizeRole.Administrator) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Administrator));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.Moderator) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Moderator));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.User) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.User));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.Banished) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Banished));
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
                        new List<string> { AuthorizeRole.Administrator, AuthorizeRole.Moderator, AuthorizeRole.User});
                }
            }
        }
    }
}