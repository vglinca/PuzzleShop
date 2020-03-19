using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PuzzleShop.Api.Middleware;
using PuzzleShop.Core;
using PuzzleShop.Core.Repository.Impl;
using PuzzleShop.Domain.Entities;
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
            services.AddControllers(cfg =>
                {
                    cfg.ReturnHttpNotAcceptable = true;
                    //cfg.OutputFormatters.Clear();
                    // cfg.OutputFormatters.Add(new NewtonsoftJsonOutputFormatter(new JsonSerializerSettings
                    // {
                    //     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    // }, ArrayPool<char>.Shared, new MvcOptions()));
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
                        //translate model state into rfc format
                        var problemDetails = new ValidationProblemDetails(ctx.ModelState)
                        {
                            Title = "One or more validation problems has occured.",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "See the errors property for details.",
                            Instance = ctx.HttpContext.Request.Path
                        };
                        problemDetails.Extensions.Add("traceId", ctx.HttpContext.TraceIdentifier);
                        
                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    };
                });

            var connString = Configuration["ConnectionStrings:PuzzleShopDbConnString"];
            services.AddDbContext<PuzzleShopContext>(
                opt => opt.UseSqlServer(connString));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPuzzleRepository, PuzzleRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMiddleware<ExceptionHandler>();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}