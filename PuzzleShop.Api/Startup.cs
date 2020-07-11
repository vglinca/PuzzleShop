using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PuzzleShop.Api.Extensions;
using PuzzleShop.Api.Services.Implementation;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Persistance.DbContext;
using PuzzleShop.Persistance.Repository;
using Serilog;
// ReSharper disable All

namespace PuzzleShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration["ConnectionStrings:PuzzleShopDbConnString"];
            services.AddDbContext<PuzzleShopContext>(opt => opt.UseSqlServer(connString));

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.ConfigureIdentity();
            
            services.Configure<IdentityOptions>(o =>{});
            
            services.AddCors();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtBearerAuthentication(authOptions);
            services.AddAuthorization();

            services.ConfigureControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPuzzleRepository, PuzzleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<ISigningInService, SigningInService>();
            services.AddTransient<IPuzzleService, PuzzleService>();
            services.AddTransient<IOrderingService, OrderingService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IPuzzleReviewService, PuzzleReviewService>();

            services.AddSwaggerGen(sa =>
            {
                sa.SwaggerDoc("PuzzleShopOpenApiSpecs", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "PuzzleShop API",
                    Version = "1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseClientExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUIMiddleware();

            app.UseExceptionMiddleware();

            app.UseSession();
            
            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseAuthorization();
            
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}