using RadioBrowserWrapper.Models;

namespace RadioBrowserWrapper.Tests;

public class CountryTests
{
    private readonly IRadioBrowser _client = new RadioBrowser(new RadioBrowserOptions
    {
        ServerUrl = "http://de1.api.radio-browser.info"
    });

    [Fact]
    public async Task GetAllCountries()
    {
        var countries = await _client.GetCountriesAsync();

        Assert.NotNull(countries);
        Assert.NotEmpty(countries);
    }

    [Fact]
    public async Task GetCountriesWithFilter()
    {
        var countries = await _client.GetCountriesAsync("at");

        Assert.NotNull(countries);
        Assert.NotEmpty(countries);
        Assert.Single(countries);
    }

    [Fact]
    public async Task GetCountriesWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        {
            Limit = 3
        };

        var countries = await _client.GetCountriesAsync(searchOptions: searchOptions);

        Assert.NotNull(countries);
        Assert.NotEmpty(countries);
        Assert.True(countries.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetCountryCodes()
    {
        var countryCodes = await _client.GetCountryCodesAsync();

        Assert.NotNull(countryCodes);
        Assert.NotEmpty(countryCodes);
    }

    [Fact]
    public async Task GetCountryCodesWithFilter()
    {
        var countryCodes = await _client.GetCountryCodesAsync("at");

        Assert.NotNull(countryCodes);
        Assert.NotEmpty(countryCodes);
        Assert.Single(countryCodes);
    }

    [Fact]
    public async Task GetCountryCodesWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        {
            Limit = 3
        };

        var countryCodes = await _client.GetCountryCodesAsync(searchOptions: searchOptions);

        Assert.NotNull(countryCodes);
        Assert.NotEmpty(countryCodes);
        Assert.True(countryCodes.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetCountryStates()
    {
        var countryStates = await _client.GetCountryStatesAsync();

        Assert.NotNull(countryStates);
        Assert.NotEmpty(countryStates);
    }

    [Fact]
    public async Task GetCountryStatesWithFilter()
    {
        var allCountryStates = await _client.GetCountryStatesAsync();
        var filteredCountryStates = await _client.GetCountryStatesAsync("ber");

        Assert.NotNull(filteredCountryStates);
        Assert.NotEmpty(filteredCountryStates);
        Assert.True(filteredCountryStates.Count() < allCountryStates.Count());
    }

    [Fact]
    public async Task GetCountryStatesWithSearchOptions()
    {
        var searchOptions = new SimpleSearchOptions
        {
            Limit = 3
        };

        var countryStates = await _client.GetCountryStatesAsync(searchOptions: searchOptions);

        Assert.NotNull(countryStates);
        Assert.NotEmpty(countryStates);
        Assert.True(countryStates.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetCountryStatesByCountry()
    {
        var countryStates = await _client.GetCountryStatesByCountryAsync("Austria");

        Assert.NotNull(countryStates);
        Assert.NotEmpty(countryStates);
    }
}
