using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable All

namespace PuzzleShop.Api.Middleware
{
	public class LoggingMiddleware
	{
		private readonly RequestDelegate _nxt;
		private readonly string _nl = Environment.NewLine;
		public LoggingMiddleware(RequestDelegate del)
		{
			_nxt = del;
		}

		public async Task Invoke(HttpContext ctx)
		{
			const string filePath = @"D:\dev\PuzzleShop\log.txt";

			var requestInfo = await HandleRequest(ctx.Request);

			var responseBodyStream = ctx.Response.Body;
			MemoryStream memStream = null;

			try
			{
				memStream = new MemoryStream();
				ctx.Response.Body = memStream;

				await _nxt(ctx);

				var responseInfo = await HandleResponse(ctx.Response);

				using (var inStream = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
				{
					using (var sr = new StreamWriter(inStream))
					{
						await sr.WriteLineAsync(requestInfo);
						await sr.WriteLineAsync(responseInfo);
					}
				}

				await memStream.CopyToAsync(responseBodyStream);
			}
			finally
			{
				if (memStream != null)
				{
					memStream.Close();
				}
			}
		}

		private async Task<string> HandleRequest(HttpRequest request)
		{
			request.EnableBuffering();

			var headers = request.Headers;

			var bodyStr = string.Empty;

			using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
			{
				bodyStr = await reader.ReadToEndAsync();
			}

			request.Body.Position = 0;

			var headersBuilder = new StringBuilder();
			foreach (var h in headers)
			{
				headersBuilder.Append($"\t{h.Key}:{h.Value}{_nl}");
			}
			
			var resultBuilder = new StringBuilder();
			resultBuilder
				.Append(GenerateTitle(DateTimeOffset.UtcNow.ToString()))
				.Append($"Scheme: {request.Scheme}{_nl}")
				.Append($"Host: {request.Host}{_nl}")
				.Append($"Path: {request.Path}{_nl}")
				.Append($"Method: {request.Method}{_nl}")
				.Append($"Headers: {_nl}{headersBuilder}")
				.Append($"Body: {bodyStr}")
				.Append(GenerateTitle(DateTimeOffset.UtcNow.ToString()));

			return resultBuilder.ToString();
		}

		private async Task<string> HandleResponse(HttpResponse resp)
		{
			resp.Body.Seek(0, SeekOrigin.Begin);
			var headers = resp.Headers;
			var bodyText = await new StreamReader(resp.Body).ReadToEndAsync();

			resp.Body.Seek(0, SeekOrigin.Begin);

			var headersBuilder = new StringBuilder();
			foreach (var h in headers)
			{
				headersBuilder.Append($"\t{h.Key}:{h.Value}{_nl}");
			}
			
			var resultBuilder = new StringBuilder();
			resultBuilder
				.Append(GenerateTitle(DateTimeOffset.UtcNow.ToString()))
				.Append($"Status code: {resp.StatusCode}{_nl}")
				.Append($"Headers: {_nl}{headersBuilder}{_nl}")
				.Append($"Response body: {bodyText}")
				.Append(GenerateTitle(DateTimeOffset.UtcNow.ToString()));
			
			return resultBuilder.ToString();
		}

		private string GenerateTitle(string title)
		{
			return $"{_nl}-------------------------------{title}----------------------------------------{_nl}";
		}
	}
}
