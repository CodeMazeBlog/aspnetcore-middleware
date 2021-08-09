using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareExample
{
	public class FactoryActivatedCustomMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			Console.WriteLine("Factory Activated Custom Middleware logic from the separate class.");

			await next.Invoke(context);
		}
	}
}
