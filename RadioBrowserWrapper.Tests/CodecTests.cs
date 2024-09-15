using RadioBrowserWrapper.Models;

namespace RadioBrowserWrapper.Tests;

public class CodecTests
{
    private readonly IRadioBrowser _client = new RadioBrowser();

    [Fact]
    public async Task GetAllCodecs()
    {
        var codecs = await _client.GetCodecsAsync();

        Assert.NotNull(codecs);
        Assert.NotEmpty(codecs);
    }

    [Fact]
    public async Task GetCodecsWithFilter()
    {
        var allCodecs = await _client.GetCodecsAsync();
        var filteredCodecs = await _client.GetCodecsAsync("AAC");

        Assert.NotNull(filteredCodecs);
        Assert.NotEmpty(filteredCodecs);
        Assert.True(filteredCodecs.Count() < allCodecs.Count());
    }

    [Fact]
    public async Task GetCodecsWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        { 
            Limit = 3
        };

        var codecs = await _client.GetCodecsAsync(searchOptions: searchOptions);

        Assert.NotNull(codecs);
        Assert.NotEmpty(codecs);
        Assert.True(codecs.Count() <= searchOptions.Limit);
    }
}
