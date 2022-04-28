using System;

using INV.ContactManager.Api.Exceptions;
using INV.ContactManager.Application.Commands.Module;
using INV.ContactManager.Application.Queries.Module;
using INV.ContactManager.Data.Adapter;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace INV.ContactManager.Api
{
	public class Program
	{
		private const string AllowAllPolicyName = "AllowAllPolicy";

		public static void Main(string[] args)
		{
			var app = SetupApplication(args);

			app.Run();
		}

		private static WebApplication SetupApplication(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			SetupLogging(builder);

			var config = BuildConfiguration();

			builder.Services.AddApplicationCommandsModule(config);
			builder.Services.AddApplicationQueriesModule(config);
			builder.Services.AddMediatR(
				typeof(Application.Queries.Module.ModuleExtensions),
				typeof(Application.Commands.Module.ModuleExtensions));

			AddSettings(builder.Services, config);

			SetupApi(builder);

			var app = builder.Build();

			WebApplicationPostSetup(app);

			return app;
		}

		private static void SetupLogging(WebApplicationBuilder builder)
		{
			builder.Logging.AddConsole();
			builder.Logging.AddDebug();
		}

		private static IConfigurationRoot BuildConfiguration()
		{
			return new ConfigurationBuilder()
							.AddJsonFile("appsettings.json", optional: false)
							.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false)
							.AddEnvironmentVariables()
							.Build();
		}

		private static void AddSettings(IServiceCollection services, IConfiguration configuration)
		{
		}

		private static void SetupApi(WebApplicationBuilder builder)
		{
			builder.Services
							.AddControllers(options =>
								options.Filters.Add(typeof(HttpResponseExceptionFilter)));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: AllowAllPolicyName,
								  builder =>
									builder
										.AllowAnyOrigin()
										.AllowAnyMethod()
										.AllowAnyHeader()
								  );
			});
		}

		private static void WebApplicationPostSetup(WebApplication app)
		{
			if (app.Environment.IsDevelopment()
				|| app.Environment.EnvironmentName == Module.Environments.Beta)
			{
				using (var scope = app.Services.CreateScope())
				{
					var context = scope.ServiceProvider.GetRequiredService<ContactManagerDBContext>();

					context.EnsureDBMigrated();
				}

				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors(AllowAllPolicyName);

			app.MapControllers();
		}
	}
}
