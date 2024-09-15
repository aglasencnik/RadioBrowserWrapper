using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RadioBrowserWrapper.Tests;

public class ServiceInstancingTests
{
    [Fact]
    public async Task UseServiceWithDefaultOptions()
    {
        var radioBrowser = new RadioBrowser();
        Assert.NotNull(radioBrowser);
    }

    [Fact]
    public async Task UseServiceWithCustomOptions()
    {
        var radioBrowser = new RadioBrowser(new RadioBrowserOptions
        {
            ServerUrl = "de1.api.radio-browser.info",
        });
        Assert.NotNull(radioBrowser);
    }

    [Fact]
    public async Task UseDependencyInjectionWithDefaultOptions()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddRadioBrowser(options =>
        {
            options.ServerUrl = "de1.api.radio-browser.info";
        });

        var serviceProvider = builder.Build().Services;

        var radioBrowser = serviceProvider.GetRequiredService<IRadioBrowser>();
        Assert.NotNull(radioBrowser);
    }

    [Fact]
    public async Task UseDependencyInjectionWithCustomOptions()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddRadioBrowser(options =>
        {
            options.ServerUrl = "de1.api.radio-browser.info";
        });

        var serviceProvider = builder.Build().Services;

        var radioBrowser = serviceProvider.GetRequiredService<IRadioBrowser>();
        Assert.NotNull(radioBrowser);
    }
}
