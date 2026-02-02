using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace app;

/// <summary>
///
/// </summary>
public static class Program
{
	/// <summary>
	///
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public static Task Main(string[] args)
		=> CreateWebHostBuilder(args).Build().RunAsync();

	private static IHostBuilder CreateWebHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
		    .ConfigureAppConfiguration(
			    (_, config) =>
			    {
				    config.AddEnvironmentVariables();
				    config.AddCommandLine(args);
			    }
		    )
		    .ConfigureWebHostDefaults(webHost => webHost.UseStartup<Startup>());
}