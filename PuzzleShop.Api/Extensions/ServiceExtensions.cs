﻿//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PuzzleShop.Api.Helpers;
using Microsoft.Extensions.Configuration;

namespace PuzzleShop.Api.Extensions
{
    public static class ServiceExtensions
    {
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
    }
}