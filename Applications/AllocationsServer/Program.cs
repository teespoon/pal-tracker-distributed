using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Pivotal.Extensions.Configuration.ConfigServer;

namespace AllocationsServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHostBuilder(args).Build();

        public static IWebHostBuilder WebHostBuilder(string[] args) =>
            ConfigServerHostBuilderExtensions.AddConfigServer(CloudFoundryHostBuilderExtensions.UseCloudFoundryHosting(WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build()))
                .AddCloudFoundry())
                .UseStartup<Startup>();
    }
}