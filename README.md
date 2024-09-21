# RadioBrowserWrapper

[![NuGet version (RadioBrowserWrapper)](https://img.shields.io/nuget/v/RadioBrowserWrapper.svg?style=flat-square)](https://www.nuget.org/packages/RadioBrowserWrapper/)

**RadioBrowserWrapper** is a lightweight and intuitive .NET wrapper for the [Radio Browser API](https://www.radio-browser.info/), designed to make it easy for developers to integrate radio station search and stream discovery into their applications.

Whether you're building a media player, an online radio directory, or any project that requires radio station information, this library provides a simple and streamlined interface to interact with the Radio Browser API.

With support for:
- Searching stations by various criteria (country, language, tag, etc.)
- Fetching detailed information about specific stations
- Adding new stations to the Radio Browser database
- Seamlessly integrating live radio streams

**RadioBrowserWrapper** enables smooth integration of live radio streams into your .NET applications.

## Installation

To use RadioBrowserWrapper in your C# project, you need to install the NuGet package. Follow these simple steps:

### Using NuGet Package Manager

1. **Open Your Project**: Open your project in Visual Studio or your preferred IDE.
2. **Open the Package Manager Console**: Navigate to `Tools` -> `NuGet Package Manager` -> `Package Manager Console`.
3. **Install RadioBrowserWrapper**: Type the following command and press Enter:
   `Install-Package RadioBrowserWrapper`

### Using .NET CLI

Alternatively, you can use .NET Core CLI to install RadioBrowserWrapper. Open your command prompt or terminal and run:

`dotnet add package RadioBrowserWrapper`

### Verifying the Installation

After installation, make sure that RadioBrowserWrapper is listed in your project dependencies to confirm successful installation.

## Usage

To get started with `RadioBrowserWrapper`, create an instance of the `RadioBrowser` class and use its methods to interact with the Radio Browser API. Below is an example of how you can retrieve various types of data:

```csharp
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
```

You can retrieve information on codecs used by radio stations:

```csharp
Console.WriteLine("Codecs:");

// Get codecs
var codecs = await radioBrowser.GetCodecsAsync();
foreach (var codec in codecs)
{
    Console.WriteLine($"{codec.Name} ({codec.StationCount})");
}
```

To get the top 10 stations by votes, use:

```csharp
Console.WriteLine("Top 10 stations:");

// Get top 10 stations
var topStations = await radioBrowser.GetTopStationsByVotesAsync(10);
foreach (var station in topStations)
{
    Console.WriteLine($"{station.Name} ({station.Url})");
}
```

To retrieve stations from a specific country, for example, Germany:

```csharp
Console.WriteLine("Stations from Germany:");

// Get first 10 stations from Germany
var gerStations = await radioBrowser.GetStationsByExactCountryAsync("Germany", new ListStationsSearchOptions
{
    Limit = 10
});

foreach (var station in gerStations)
{
    Console.WriteLine($"{station.Name} ({station.Url})");
}
```

You can also vote for a station by its UUID:

```csharp
// Vote for the first station in the top stations list
await radioBrowser.VoteStationAsync(topStations.FirstOrDefault()!.StationUuid);
```

### Dependency Injection and Instancing

There are different ways to create an instance of `RadioBrowser` in your project, either by instantiating it directly or using dependency injection (DI) in ASP.NET Core or other DI frameworks.

#### Instantiating Directly

You can create an instance of `RadioBrowser` with default or custom options:

```csharp
// Default options
var radioBrowser = new RadioBrowser();

// Custom server URL
var radioBrowser = new RadioBrowser(new RadioBrowserOptions
{
    ServerUrl = "de1.api.radio-browser.info"
});
```

#### Using Dependency Injection (DI)

You can also configure `RadioBrowser` to be injected via the service container, making it easier to use in DI-heavy environments like ASP.NET Core:

1. **With Default Options**

```csharp
var builder = Host.CreateApplicationBuilder();

// Add RadioBrowser to the service collection with default options
builder.Services.AddRadioBrowser();

var serviceProvider = builder.Build().Services;
var radioBrowser = serviceProvider.GetRequiredService<IRadioBrowser>();
```

2. **With Custom Options**

```csharp
var builder = Host.CreateApplicationBuilder();

// Add RadioBrowser to the service collection with custom options
builder.Services.AddRadioBrowser(options =>
{
    options.ServerUrl = "de1.api.radio-browser.info";
});

var serviceProvider = builder.Build().Services;
var radioBrowser = serviceProvider.GetRequiredService<IRadioBrowser>();
```

In both cases, you can retrieve an `IRadioBrowser` instance from the service provider and use it in your project.

### Explore More

The `RadioBrowserWrapper` package wraps all available endpoints provided by the Radio Browser API, enabling you to interact with a wide range of functionality. Beyond the examples shown, you can:

- Search stations by tags, language, or bitrate.
- Retrieve stations by name, exact URL, or UUID.
- Get statistics like the number of active stations or the total number of countries.
- Server statistics
- Filter stations based on codec, bitrate, or country.
- and much more

With many customizable search options and methods, there is plenty to explore within the library.

## Support the Project

If you find this project useful, consider supporting it by [buying me a coffee](https://www.buymeacoffee.com/aglasencnik). Your support is greatly appreciated!

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/aglasencnik)

## Contributing

Contributions are welcome! If you have a feature to propose or a bug to fix, create a new pull request.

## License

This project is licensed under the [MIT License](https://github.com/aglasencnik/RadioBrowserWrapper/blob/main/LICENSE).

## Acknowledgment

This project is inspired by and built upon the [Radio Browser](https://www.radio-browser.info/) project.
