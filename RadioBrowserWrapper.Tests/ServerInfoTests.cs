namespace RadioBrowserWrapper.Tests;

public class ServerInfoTests
{
    private readonly IRadioBrowser _client = new RadioBrowser(new RadioBrowserOptions
    {
        ServerUrl = "http://de1.api.radio-browser.info"
    });

    [Fact]
    public async Task GetServerStats()
    {
        var result = await _client.GetServerStatsAsync();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetServerMirrors()
    {
        var result = await _client.GetServerMirrorsAsync();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetServerConfig()
    {
        var result = await _client.GetServerConfigAsync();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetPrometheusMonitoringResult()
    {
        var result = await _client.GetPrometheusMonitoringResultAsync();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
