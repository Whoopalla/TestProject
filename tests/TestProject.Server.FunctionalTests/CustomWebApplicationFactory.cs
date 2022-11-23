using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestProject.Server.Core.Services;

namespace TestProject.Server.FunctionalTests;
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class {
    /// <summary>
    /// Overriding CreateHost to avoid creating a separate ServiceProvider per this thread:
    /// https://github.com/dotnet-architecture/eShopOnWeb/issues/465
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    protected override IHost CreateHost(IHostBuilder builder) {
        var host = builder.Build();
        builder.ConfigureWebHost(ConfigureWebHost);

        // Get service provider.
        var serviceProvider = host.Services;

        host.Start();
        return host;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder) {
        builder
            .ConfigureServices(services => {
                services.AddScoped<IArraySumFinder, ArraySumFinder>();
                services.AddScoped<ILinkedListAddingService, TwoLinkedListsAddingService>();
                services.AddScoped<IPalindromeDetector, PalindromeDetector>();
            });
    }
}
