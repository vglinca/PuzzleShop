using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PuzzleShop.Core.Exceptions;
// ReSharper disable All

namespace PuzzleShop.Api.Middleware
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _nxt;

		public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
		{
			_nxt = requestDelegate;
		}

		public async Task Invoke(HttpContext ctx)
		{
			try
			{
				await _nxt.Invoke(ctx);
			}
			catch (EntityNotFoundException e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.NotFound);
			}
			catch (BadRequestException e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.BadRequest);
			}
			catch (UnauthorizedException e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.Unauthorized);
			}
			catch (AuthenticationFailedException e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.Unauthorized);
			}
			catch(InternalServerErrorException e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.InternalServerError);
			}
			catch (Exception e)
			{
				await HandleExceptionAsync(ctx, e, HttpStatusCode.InternalServerError);
			}
		}

		private async Task HandleExceptionAsync(HttpContext ctx, Exception ex, HttpStatusCode statusCode)
		{
			var response = ctx.Response;
			response.ContentType = "application/problem+json";
			response.StatusCode = (int) statusCode;
			await response.WriteAsync(JsonConvert.SerializeObject(new
			{
				StatusCode = (int) statusCode,
				Error = ex.Message
			}));
		}
	}
}