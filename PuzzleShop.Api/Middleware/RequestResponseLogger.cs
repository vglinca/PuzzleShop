using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Middleware
{
	public class RequestResponseLogger
	{
		private readonly RequestDelegate _nxt;
		private readonly string nl = Environment.NewLine;
		private readonly string delimeter;
		public RequestResponseLogger(RequestDelegate del)
		{
			_nxt = del;
			delimeter = $"{nl}---------------------------{DateTime.Now}-------------------------------{nl}";
		}

		public async Task Invoke(HttpContext ctx)
		{
			var filePath = @"D:\dev\PuzzleShop\log.txt";
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
			}

			var requestInfo = await HandleRequest(ctx.Request);

			var responseBodyStream = ctx.Response.Body;
			MemoryStream memStream = null;

			try
			{
				memStream = new MemoryStream();
				ctx.Response.Body = memStream;

				await _nxt(ctx);

				var responseInfo = await HandleResponse(ctx.Response);

				using (var sr = new StreamWriter(filePath, true))
				{
					await sr.WriteLineAsync(requestInfo);
					await sr.WriteLineAsync(responseInfo);
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
			var body = request.Body;

			request.EnableBuffering();

			var headers = request.Headers;

			var buf = new byte[Convert.ToInt32(request.ContentLength)];

			await request.Body.ReadAsync(buf, 0, buf.Length);

			request.Body = body;
			var bodyAsString = Encoding.UTF8.GetString(buf);

			var headersBuilder = new StringBuilder();
			foreach (var h in headers)
			{
				headersBuilder.Append($"{h.Key}:{h.Value}{nl}");

			}
			return $"{delimeter}Scheme: {request.Scheme}{nl}Host: {request.Host}{nl}" +
				$"Path: {request.Path}{nl}Method: {request.Method}{nl}" +
				$"Headers: {headersBuilder}{nl}Body: {bodyAsString}{delimeter}";
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
				headersBuilder.Append($"{h.Key}:{h.Value}{nl}");
			}
			return $"{delimeter}Status code: {resp.StatusCode}{nl}Headers: {headersBuilder}{nl}" +
			$"Response body: {bodyText}{delimeter}";
		}
	}
}
