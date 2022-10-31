

# Folidata.SDK.CSharp
This c# example libary is a SDK for the folidata finance api service. 
With this SDK you can download end-of-day historic stock prices and prices for other assets like cryptos, indices, etc. 

[![License: MIT](https://img.shields.io/github/license/stefanprodan/AspNetCoreRateLimit.svg)](https://opensource.org/licenses/MIT)

## Compatibility
The library is written in:
[![.NET Version](https://img.shields.io/badge/.NET6.0-blue)](https://shields.io/)

# Contents
1. [General](#general)
2. [Requirements](#requirements)
3. [Documentation](#documentation)

## General
This C# example library is an SDK for the folidata finance API service. 
With this SDK you can download end-of-day historic stock prices and prices for other assets like cryptos, indices, etc. 

## Requirements
To use this API you need an API key.  You can register for a free API key at [www.folidata.com](https://www.folidata.com/). Actually, the site language is in German.

With a free account you can use this API for 100 API calls a day.
For more API calls you can submit for a paid package.

## Documentation
A full documentation is available under [this link](https://www.folidata.com/documentation) (actually in German).
But the API is easy to use:

### Init
With the following code, you init the http client with your personal API key:
```c#
using Folidata;
var key = "YOUR_API_KEY";
var api = new FolidataApi(key);
```
### List of stock exchanges and supported symbols
To get the full list of supported exchanges use this code:
```c#
var exchanges = await _api.GetExchangeAsync()
```

Then you can get all the symbols of a stock exchange:
```c#
var exchanges = await _api.GetSymbolsAsync("US")
```

Other supported lists to get the supported symbols:
- Crypto **GetCryptosAsync()**
- Forex Pairs **GetForexAsync()**
- Futures **GetFuturesAsync()**


### Historical End-Of-Day Prices
Just one line of code is enough to get the all historic prices for the apple stock.
```c#
var prices = await api.GetPricesAsync("AAPL.US");
```

To get data for a specific day:
```c#
var prices = await api.GetPriceAsync("AAPL.US",new DateTime(2022, 01, 02));
```
For a specific time range:
```c#
var prices = await api.GetPricesAsync("AAPL.US",new DateTime(2021, 01, 02), new DateTime(2022, 06, 01));
```
Sort the result:
```c#
var prices = await api.GetPricesAsync("AAPL.US", new DateTime(2021, 01, 02), new DateTime(2022, 06, 01), Folidata.Utils.SortMode.DESC);
```
Limit the results:
```c#
var prices = await api.GetPricesAsync("AAPL.US", new DateTime(2021, 01, 02), new DateTime(2022, 06, 01), Folidata.Utils.SortMode.DESC, 100);
```

All given parameters/methods are also possible in the following methods:
- GetCryptoPricesAsync("SHIB-USD")
- GetForexPricesAsync("USDEUR")
- GetFuturePricesAsync("GC")
- GetIndexPricesAsync("GDAXP")

### Key State
To check your current limits and datapoints count:
```c#
var state = await api.GetKeyStateAsync();
```