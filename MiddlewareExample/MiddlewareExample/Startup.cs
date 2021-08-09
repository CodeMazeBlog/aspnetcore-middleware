using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MiddlewareExample
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<FactoryActivatedCustomMiddleware>();
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.Use(async (context, next) =>
			{
				Console.WriteLine($"Logic before executing the next delegate in the Use method");

				await next.Invoke();

				Console.WriteLine($"Logic after executing the next delegate in the Use method");
			});

			app.UseCustomMiddleware();
			app.UseFactoryActivatedCustomMiddleware();

			app.Map("/usingmapbranch", builder =>
			{
				builder.Use(async (context, next) =>
				{
					Console.WriteLine("Map branch logic in the Use method before the next delegate");

					await next.Invoke();

					Console.WriteLine("Map branch logic in the Use method after the next delegate");
				});
				builder.Run(async context =>
				{
					Console.WriteLine($"Map branch response to the client in the Run method");

					await context.Response.WriteAsync("Hello from the map branch.");
				});
			});

			app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder =>
			{
				builder.Run(async context =>
				{
					await context.Response.WriteAsync("Hello from the MapWhen branch.");
				});
			});

			app.Run(async context =>
			{
				Console.WriteLine($"Writing the response to the client in the Run method");

				await context.Response.WriteAsync("Hello from the middleware component.");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
