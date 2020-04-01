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
			app.Use(async (ctx, next) =>
			{
				var token = ctx.Session.GetString("JWToken");
				if (! string.IsNullOrWhiteSpace(token))
				{
					ctx.Request.Headers.Add("Authorization", $"Bearer {token}");
				}
            
				await next();
			});
		}
	}
}
