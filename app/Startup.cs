using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace app;

/// <summary>
///
/// </summary>
/// <param name="configuration"></param>
public class Startup(IConfiguration configuration)
{
	private readonly IConfigurationRoot _configurationRoot = (IConfigurationRoot)configuration;

	/// <summary>
	/// </summary>
	/// <param name="services"></param>
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddCors();
		services.AddResponseCompression(
			options =>
			{
				options.EnableForHttps = true;
				options.Providers.Add<GzipCompressionProvider>();
			}
		);
		services.AddLogging(
			configure =>
			{
				configure.AddSimpleConsole(options =>
				{
					options.IncludeScopes   = true;
					options.SingleLine      = true;
					options.TimestampFormat = "[hh:mm:ss] ";
					options.ColorBehavior   = LoggerColorBehavior.Enabled;
				});
			}
		);

		services.AddMvc();
		services.AddWordPress(options =>
		{
			options.SiteUrl =
			options.HomeUrl = "http://localhost:5004/wp";
			// options.PluginContainer.Add<DashboardPlugin>(); // add plugin using dependency injection
		});
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="app"></param>
	/// <param name="env"></param>
	/// <param name="configuration"></param>
	public void Configure(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseWordPress();

		app.UseDefaultFiles();
	}
}