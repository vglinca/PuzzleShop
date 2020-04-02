using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PuzzleShop.Api.Middleware;

namespace PuzzleShop.Api.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandlerMiddleware>();
		}

		public static void UseLoggingMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<LoggingMiddleware>();
		}

		public static void UseTokenInsertionMiddleware(this IApplicationBuilder app)
		{
			app.Use(async (ctx, nxt) =>
			{
				var token = ctx.Session.GetString("JWToken");
				if (! string.IsNullOrWhiteSpace(token))
				{
					ctx.Request.Headers.Add("Authorization", $"Bearer {token}");
				}
            
				await nxt();
			});
		}

		public static void UseSwaggerUIMiddleware(this IApplicationBuilder app)
		{
			app.UseSwaggerUI(sa =>
			{
				sa.SwaggerEndpoint("/swagger/PuzzleShopOpenApiSpecs/swagger.json", "PuzzleShop API");
			});
		}

		public static void UseClientExceptionPage(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(appBuilder =>
			{
				appBuilder.Run(async ctx =>
				{
					ctx.Response.StatusCode = 500;
					await ctx.Response.WriteAsync("An unexpecter fault happened. Try again later");
				});
			});
		}
	}
}
