<h1>A .NET/C# implementation of the Check WX METAR TAF STATION REST API</h1>

Website: https://checkwx.com/

API Documentation: https://api.checkwx.com/

This is .NET/C# wrapper which can be used to interact with the Check WX METAR/TAF/STATION API. This projecty has only one dependency: Newtonsoft.Json v. 9.0.1+ (https://www.nuget.org/packages/newtonsoft.json/) 

The wrapper is written to give users three ways of communicating with the API: 

1. The RAW JSON services which will deliver the raw JSON response and HTTP status code from the API.
2. The RAW XML services which will deliver the raw XML response and HTTP status code from the API.
2. The .NET object services which will deserialize and deliver domain objects from the delivered JSON

<h3>Prerequisites - Before you begin you need the following:</h3>
- The latest release of this package
- The latest version of Newtonsoft.Json (9.0.1+). Download it via NuGet.
- An API key from Check MX (free, 2000 request/day limit): https://www.streak.com/api/#apikey

<h3>API services with domain models (.NET)</h3>
You can use the services like this:

```C#
var checkWxServices = new CheckWxServices("{YOUR_API_KEY");
var metarEkah = checkWxServices.Metars.SingleDecoded("EKAH"); // Returns current METAR for EKAH
var tafEkah = checkWxServices.Tafs.SingleDecoded("EKAH"); // Returns current TAF for EKAH
var ekah = checkWxServices.Stations.Single("EKAH"); // Returns station info about EKAH
```

<h3>RAW JSON/XML services</h3>
You can use the RAW services (JSON / XML) like this:

```C#
var checkWxServices = new CheckWxServices("{YOUR_API_KEY");

var metarJsonEkahRaw = checkWxServices.JsonMetars.SingleRaw("EKAH"); // Returns current METAR for EKAH as a string
var metarJsonEkahDecoded = checkWxServices.JsonMetars.SingleDecoded("EKAH"); // Returns current METAR for EKAH as a JSON object (string)

var metarXmlEkahRaw = checkWxServices.JsonMetars.SingleRaw("EKAH"); // Returns current METAR for EKAH as a string
```

<h3>Errors</h3>
When using the strongly typed API (.NET objects) all returned types has the following two properties:

```C#
/// <summary>
/// Indicates that there was an error retrieving the data
/// </summary>
public bool Error { get; set; }
/// <summary>
/// The error text from the API
/// </summary>
public string ErrorText { get; set; }
```

If the API returns an error the Error boolean is set to true and the error text from the API is attached as ErrorText. The latter can be used for debugging purposes.
