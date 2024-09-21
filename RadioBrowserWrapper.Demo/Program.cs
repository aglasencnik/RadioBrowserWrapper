using RadioBrowserWrapper;
using RadioBrowserWrapper.Models;

var radioBrowser = new RadioBrowser();

Console.WriteLine("Countries:");

// Get the first 10 countries
var countries = await radioBrowser.GetCountriesAsync(searchOptions: new SimpleSearchOptions
{
    Limit = 10
});

foreach (var country in countries)
{
    Console.WriteLine($"{country.Name} ({country.ISO_3166_1})");
}

Console.WriteLine("\nCodecs:");

// Get codecs
var codecs = await radioBrowser.GetCodecsAsync();
foreach (var codec in codecs)
{
    Console.WriteLine($"{codec.Name} ({codec.StationCount})");
}

Console.WriteLine("\nTop 10 stations:");

// Get top 10 stations
var topStation = await radioBrowser.GetTopStationsByVotesAsync(10);
foreach (var station in topStation)
{
    Console.WriteLine($"{station.Name} ({station.Url})");
}

Console.WriteLine("\nStations from Germany:");

// Get first 10 stations from Germany
var gerStations = await radioBrowser.GetStationsByExactCountryAsync("Germany", new ListStationsSearchOptions
{
    Limit = 10
});

foreach (var station in gerStations)
{
    Console.WriteLine($"{station.Name} ({station.Url})");
}

// Vote for the first station
await radioBrowser.VoteStationAsync(topStation.FirstOrDefault()!.StationUuid);
