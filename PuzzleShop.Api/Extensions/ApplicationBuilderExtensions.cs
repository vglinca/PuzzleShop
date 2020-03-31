using Microsoft.AspNetCore.Builder;
using PuzzleShop.Api.Middleware;

namespace PuzzleShop.Api.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ExceptionHandler>();
		}
	}
}
