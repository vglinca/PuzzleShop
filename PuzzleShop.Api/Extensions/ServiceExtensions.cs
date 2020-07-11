//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PuzzleShop.Api.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PuzzleShop.Persistance.DbContext;
using Microsoft.AspNetCore.Identity;
using PuzzleShop.Core.Entities.Auth;

namespace PuzzleShop.Api.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureControllers(this IServiceCollection services)
        {
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
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(o =>
            {
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<PuzzleShopContext>()
                .AddRoleManager<RoleManager<Role>>()
                .AddErrorDescriber<IdentityErrorDescriber>();
        }

        public static void AddJwtBearerAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.AddAuthentication(cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
                    };
                });
        }

        public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptionsConfigurationSection = configuration.GetSection("AuthOptions");
            services.Configure<AuthOptions>(authOptionsConfigurationSection);
            var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
            return authOptions;
        }

        public static StripeApiSecret ConfigureStripeApiSecret(this IServiceCollection services,
            IConfiguration configuration)
        {
            var stripeApiSection = configuration.GetSection("StripeApiSecret");
            services.Configure<StripeApiSecret>(stripeApiSection);
            var apiSecret = stripeApiSection.Get<StripeApiSecret>();
            return apiSecret;
        }
    }
}