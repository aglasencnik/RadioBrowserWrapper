using RadioBrowserWrapper.Models;

namespace RadioBrowserWrapper.Tests;

public class TagTests
{
    private readonly IRadioBrowser _client = new RadioBrowser(new RadioBrowserOptions
    {
        ServerUrl = "http://de1.api.radio-browser.info"
    });

    [Fact]
    public async Task GetAllTags()
    {
        var tags = await _client.GetTagsAsync();

        Assert.NotNull(tags);
        Assert.NotEmpty(tags);
    }

    [Fact]
    public async Task GetTagsWithFilter()
    {
        var allTags = await _client.GetTagsAsync();
        var filteredTags = await _client.GetTagsAsync("10s");

        Assert.NotNull(filteredTags);
        Assert.NotEmpty(filteredTags);
        Assert.True(filteredTags.Count() < allTags.Count());
    }

    [Fact]
    public async Task GetTagsWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        {
            Limit = 3
        };

        var tags = await _client.GetTagsAsync(searchOptions: searchOptions);

        Assert.NotNull(tags);
        Assert.NotEmpty(tags);
        Assert.True(tags.Count() <= searchOptions.Limit);
    }
}
