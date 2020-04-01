using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PuzzleShop.Api.Extensions;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Domain.Entities.Auth;
using PuzzleShop.Persistance.DbContext;
// ReSharper disable All

namespace PuzzleShop.Api
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				try
				{
					var ctx = scope.ServiceProvider.GetService<PuzzleShopContext>();
					ctx.Database.Migrate();
					var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
					var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
					await RoleInitializer.InitializeAsync(roleManager, userManager);
				}
				catch (Exception ex)
				{
					var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while migrating the database.");
				}
			}
			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host
			.CreateDefaultBuilder(args)
			.ConfigureLogging((hostingCtx, logger) =>
			{
				logger.ClearProviders();
				logger.AddConfiguration(hostingCtx.Configuration.GetSection("Logging"));
				logger.AddConsole();
				logger.AddEventSourceLogger();
			})
			.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
	}
}