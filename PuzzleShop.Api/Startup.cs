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
using PuzzleShop.Api.Services.Impl;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Repository.Impl;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities.Auth;
using PuzzleShop.Persistance.DbContext;
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
            services.AddDbContext<PuzzleShopContext>(
                opt => opt.UseSqlServer(connString));
            
           services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            
            services.AddIdentity<User, Role>(o =>
            {
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
                
            }).AddRoles<Role>()
                .AddEntityFrameworkStores<PuzzleShopContext>()
                .AddRoleManager<RoleManager<Role>>()
                .AddErrorDescriber<IdentityErrorDescriber>();
            
            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
            });
            
            services.AddCors();

            //var authOptionsSection = Configuration.GetSection("AuthOptions");
            //services.Configure<AuthOptions>(authOptionsSection);
            //var authOptions = authOptionsSection.Get<AuthOptions>();
            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtBearerAuthentication(authOptions);

            services.AddAuthorization(
                //     cfg =>
                // {
                //     cfg.AddPolicy("admin", policyBuilder => { policyBuilder.RequireRole("admin"); });
                //     cfg.AddPolicy("user", policyBuilder => { policyBuilder.RequireRole("user"); });
                //     cfg.AddPolicy("moderator", policyBuilder => { policyBuilder.RequireRole("moderator"); });
                // }
            );
            
            services.AddControllers(cfg =>
                {
                    cfg.Filters.Add(new AuthorizeFilter());
                    cfg.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(cfg =>
                {
                    cfg.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(cfg =>
                {
                    //configure how the api controller should behave
                    //handle validation problems errors
                    //this factory will be execured when the model state is invalid
                    cfg.InvalidModelStateResponseFactory = ctx =>
                    {
                        var problemDetails = new ValidationProblemDetails(ctx.ModelState)
                        {
                            Title = "One or more validation problems has occured.",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "See the 'errors' property for details.",
                            Instance = ctx.HttpContext.Request.Path
                        };
                        problemDetails.Extensions.Add("traceId", ctx.HttpContext.TraceIdentifier);
                        
                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    };
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped(typeof(IImageRepository<>), typeof(Repository<>));
            services.AddScoped<IPuzzleRepository, PuzzleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<ISigningInService, SigningInService>();
            services.AddTransient<IOrderingService, OrderingService>();

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
            // else
            // {
            //     app.UseClientExceptionPage();
            // }

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUIMiddleware();

            app.UseExceptionMiddleware();

            app.UseSession();
            
            app.UseTokenInsertionMiddleware();
            
            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseAuthorization();
            
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //app.UseLoggingMiddleware();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}