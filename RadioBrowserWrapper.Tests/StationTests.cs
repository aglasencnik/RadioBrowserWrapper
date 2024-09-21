using RadioBrowserWrapper.Models;

namespace RadioBrowserWrapper.Tests;

public class StationTests
{
    private readonly IRadioBrowser _client = new RadioBrowser(new RadioBrowserOptions
    {
        ServerUrl = "http://de1.api.radio-browser.info"
    });

    #region List

    [Fact]
    public async Task GetAllStations()
    {
        var stations = await _client.GetAllStationsAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByName()
    {
        var stations = await _client.GetStationsByNameAsync("rock");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByNameWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByNameAsync("rock", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactName()
    {
        var stations = await _client.GetStationsByExactNameAsync("rock");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactNameWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactNameAsync("rock", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByCodec()
    {
        var stations = await _client.GetStationsByCodecAsync("mp3");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByCodecWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByCodecAsync("mp3", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactCodec()
    {
        var stations = await _client.GetStationsByExactCodecAsync("mp3");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactCodecWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactCodecAsync("mp3", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByCountry()
    {
        var stations = await _client.GetStationsByCountryAsync("germany");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByCountryWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByCountryAsync("germany", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactCountry()
    {
        var stations = await _client.GetStationsByExactCountryAsync("germany");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactCountryWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactCountryAsync("germany", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactCountryCode()
    {
        var stations = await _client.GetStationsByExactCountryCodeAsync("DE");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactCountryCodeWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactCountryCodeAsync("DE", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByState()
    {
        var stations = await _client.GetStationsByStateAsync("berlin");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByStateWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByStateAsync("berlin", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactState()
    {
        var stations = await _client.GetStationsByExactStateAsync("berlin");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactStateWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactStateAsync("berlin", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByLanguage()
    {
        var stations = await _client.GetStationsByLanguageAsync("german");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByLanguageWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByLanguageAsync("german", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactLanguage()
    {
        var stations = await _client.GetStationsByExactLanguageAsync("german");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactLanguageWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactLanguageAsync("german", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByTag()
    {
        var stations = await _client.GetStationsByTagAsync("rock");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByTagWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByTagAsync("rock", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationsByExactTag()
    {
        var stations = await _client.GetStationsByExactTagAsync("rock");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetStationsByExactTagWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetStationsByExactTagAsync("rock", searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetAllStationsWithSearchOptions()
    {
        var searchOptions = new ListStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetAllStationsAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationCheckResults()
    {
        var stationCheckResults = await _client.GetStationCheckResultsAsync();

        Assert.NotNull(stationCheckResults);
        Assert.NotEmpty(stationCheckResults);
    }

    [Fact]
    public async Task GetStationCheckResultsByStationUuid()
    {
        var stationCheckResults = await _client.GetStationCheckResultsAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(stationCheckResults);
        Assert.NotEmpty(stationCheckResults);
        Assert.All(stationCheckResults, x => Assert.Equal("07450589-fad3-485d-8a49-294ff3038bef", x.StationUuid));
    }

    [Fact]
    public async Task GetStationClicks()
    {
        var stationClicks = await _client.GetStationClicksAsync();

        Assert.NotNull(stationClicks);
        Assert.NotEmpty(stationClicks);
    }

    [Fact]
    public async Task GetStationClicksWithStationUuid()
    {
        var stationClicks = await _client.GetStationClicksAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(stationClicks);
        Assert.NotEmpty(stationClicks);
        Assert.All(stationClicks, x => Assert.Equal("07450589-fad3-485d-8a49-294ff3038bef", x.StationUuid));
    }

    [Fact]
    public async Task GetStationCheckSteps()
    {
        var stationCheckSteps = await _client.GetStationCheckStepsAsync(["07450589-fad3-485d-8a49-294ff3038bef", "394c0c15-b64b-4d82-8be3-4e54afa0d475"]);

        Assert.NotNull(stationCheckSteps);
        Assert.NotEmpty(stationCheckSteps);
    }

    [Fact]
    public async Task SearchStations()
    {
        var searchOptions = new AdvancedStationSearchOptions
        {
            Name = "rock",
            Limit = 3
        };

        var stations = await _client.SearchStationsAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetStationByUuid()
    {
        var station = await _client.GetStationByUuidAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(station);
    }

    [Fact]
    public async Task GetStationsByMultipleUuids()
    {
        var stations = await _client.SearchStationsByUuid(["07450589-fad3-485d-8a49-294ff3038bef", "394c0c15-b64b-4d82-8be3-4e54afa0d475"]);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() == 2);
    }

    [Fact]
    public async Task GetStationsByUrl()
    {
        var stations = await _client.GetStationsByUrlAsync("http://stream.laut.fm/1000-electronic-dance-music");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    #endregion

    #region Search

    [Fact]
    public async Task GetTopStationsByClicks()
    {
        var stations = await _client.GetTopStationsByClicksAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetTopStationsByClicksWithSearchOptions()
    {
        var searchOptions = new StationSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetTopStationsByClicksAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetTopStationsByClicksWithStationCount()
    {
        var stations = await _client.GetTopStationsByClicksAsync(3);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= 3);
    }

    [Fact]
    public async Task GetTopStationsByVotes()
    {
        var stations = await _client.GetTopStationsByVotesAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetTopStationsByVotesWithSearchOptions()
    {
        var searchOptions = new StationSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetTopStationsByVotesAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetTopStationsByVotesWithStationCount()
    {
        var stations = await _client.GetTopStationsByVotesAsync(3);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= 3);
    }

    [Fact]
    public async Task GetTopStationsByRecentClicks()
    {
        var stations = await _client.GetTopStationsByRecentClicksAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetTopStationsByRecentClicksWithSearchOptions()
    {
        var searchOptions = new StationSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetTopStationsByRecentClicksAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetTopStationsByRecentClicksWithStationCount()
    {
        var stations = await _client.GetTopStationsByRecentClicksAsync(3);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= 3);
    }

    [Fact]
    public async Task GetRecentlyChangedStations()
    {
        var stations = await _client.GetRecentlyChangedStationsAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetRecentlyChangedStationsWithSearchOptions()
    {
        var searchOptions = new StationSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetRecentlyChangedStationsAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetRecentlyChangedStationsWithStationCount()
    {
        var stations = await _client.GetRecentlyChangedStationsAsync(3);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= 3);
    }

    [Fact]
    public async Task GetOldVersionsOfStations()
    {
        var stations = await _client.GetOldVersionsOfStationsAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetOldVersionsOfStationsWithSearchOptions()
    {
        var searchOptions = new OldVersionsOfStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetOldVersionsOfStationsAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetOldVersionsOfStationsWithStationUuid()
    {
        var stations = await _client.GetOldVersionsOfStationsAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetBrokenStations()
    {
        var stations = await _client.GetBrokenStationsAsync();

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
    }

    [Fact]
    public async Task GetBrokenStationsWithSearchOptions()
    {
        var searchOptions = new BrokenStationsSearchOptions
        {
            Limit = 3
        };

        var stations = await _client.GetBrokenStationsAsync(searchOptions: searchOptions);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= searchOptions.Limit);
    }

    [Fact]
    public async Task GetBrokenStationsWithStationCount()
    {
        var stations = await _client.GetBrokenStationsAsync(3);

        Assert.NotNull(stations);
        Assert.NotEmpty(stations);
        Assert.True(stations.Count() <= 3);
    }

    #endregion

    #region Modify

    [Fact]
    public async Task ClickValidStation()
    {
        var response = await _client.ClickStationAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(response);
        Assert.True(response.IsOk);
    }

    [Fact]
    public async Task ClickInvalidStation()
    {
        var response = await _client.ClickStationAsync("invalid");

        Assert.NotNull(response);
        Assert.False(response.IsOk);
    }

    [Fact]
    public async Task VoteValidStation()
    {
        var response = await _client.VoteStationAsync("07450589-fad3-485d-8a49-294ff3038bef");

        Assert.NotNull(response);
    }

    [Fact]
    public async Task VoteInvalidStation()
    {
        var response = await _client.VoteStationAsync("invalid");

        Assert.NotNull(response);
        Assert.False(response.IsOk);
    }

    #endregion
}
