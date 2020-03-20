using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PuzzleShop.Core.Exceptions;
// ReSharper disable All

namespace PuzzleShop.Api.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _requestDelegate.Invoke(ctx);
            } catch (EntityNotFoundException e)
            {
                await HandleException(ctx, e, HttpStatusCode.NotFound);
            } catch (BadRequestException e)
            {
                await HandleException(ctx, e, HttpStatusCode.BadRequest);
            } catch (UnauthorizedException e)
            {
                await HandleException(ctx, e, HttpStatusCode.Unauthorized);
            } catch (AuthenticationFailedException e)
            {
                await HandleException(ctx, e, HttpStatusCode.Unauthorized);
            }
        }

        private async Task HandleException(HttpContext ctx, Exception ex, HttpStatusCode statusCode)
        {
            var response = ctx.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int) statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Error = ex.Message
            }));
        }
    }
}