using RadioBrowserWrapper.Models;

namespace RadioBrowserWrapper.Tests;

public class LanguageTests
{
    private readonly IRadioBrowser _client = new RadioBrowser();

    [Fact]
    public async Task GetAllLanguages()
    {
        var languages = await _client.GetLanguagesAsync();

        Assert.NotNull(languages);
        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task GetLanguagesWithFilter()
    {
        var allLanguages = await _client.GetLanguagesAsync();
        var filteredLanguages = await _client.GetLanguagesAsync("aus");

        Assert.NotNull(filteredLanguages);
        Assert.NotEmpty(filteredLanguages);
        Assert.True(filteredLanguages.Count() < allLanguages.Count());
    }

    [Fact]
    public async Task GetLanguagesWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        {
            Limit = 3
        };

        var languages = await _client.GetLanguagesAsync(searchOptions: searchOptions);

        Assert.NotNull(languages);
        Assert.NotEmpty(languages);
        Assert.True(languages.Count() <= searchOptions.Limit);
    }
}
