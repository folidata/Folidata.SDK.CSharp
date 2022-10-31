using Folidata.Apis;
using Folidata.Contracts;
using Folidata.Model.Eod;
using Folidata.Model.General;
using Folidata.Utils;

namespace Folidata;

/// <summary>
/// folidata client to access the public api with the given key
/// </summary>
public class FolidataApi
{
    private readonly IEndOfDayAPI _endOfDayAPI;
    private readonly IGeneralAPI _generalAPI;

    /// <summary>
    /// Constructor fasade class API.eod
    /// </summary>
    /// <param name="key">your personal api key</param>
    /// <param name="url">[optional] the url to the api endpoint</param>
    public FolidataApi(string key, string url = "")
    {
        _endOfDayAPI = new EndOfDayAPI(key, url);
        _generalAPI = new GeneralAPI(key, url);
    }

    /// <summary>
    /// get historic end-of-day crypto price for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public async Task<PriceCryptoApiDto> GetCryptoPriceAsync(string symbol, DateTime? date)
    {
        symbol = AddCryptoExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPriceAsync<PriceCryptoApiDto>(symbol, date);
    }

    /// <summary>
    /// get all-time historic end-of-day crypto prices
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceCryptoApiDto>> GetCryptoPricesAsync(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddCryptoExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceCryptoApiDto>>(symbol, sort, limit);
    }

    /// <summary>
    /// historic end-of-day crypto prices in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceCryptoApiDto>> GetCryptoPricesAsync(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddCryptoExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceCryptoApiDto>>(symbol, from, to, sort, limit);
    }

    /// <summary>
    /// get the full list of all cryptos
    /// </summary>
    public async Task<List<CryptosApiDto>> GetCryptosAsync()
    {
        return await _generalAPI.GetCryptosAsync();
    }

    /// <summary>
    /// get the full list of all exchanges
    /// </summary>
    public async Task<List<ExchangesApiDto>> GetExchangeAsync()
    {
        return await _generalAPI.GetExchangeAsync();
    }

    /// <summary>
    /// get the full list of all forex pairs
    /// </summary>
    public async Task<List<ForexApiDto>> GetForexAsync()
    {
        return await _generalAPI.GetForexAsync();
    }

    /// <summary>
    /// get historic end-of-day forex for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public async Task<PriceForexApiDto> GetForexPriceAsync(string symbol, DateTime? date)
    {
        symbol = AddForexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPriceAsync<PriceForexApiDto>(symbol, date);
    }

    /// <summary>
    /// get all-time historic end-of-day forex pair
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceForexApiDto>> GetForexPricesAsync(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddForexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceForexApiDto>>(symbol, sort, limit);
    }

    /// <summary>
    /// historic end-of-day forex pairs in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceForexApiDto>> GetForexPricesAsync(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddForexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceForexApiDto>>(symbol, from, to, sort, limit);
    }

    /// <summary>
    /// get historic end-of-day future price for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public async Task<PriceFutureApiDto> GetFuturePriceAsync(string symbol, DateTime? date)
    {
        symbol = AddFutureExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPriceAsync<PriceFutureApiDto>(symbol, date);
    }

    /// <summary>
    /// get all-time historic end-of-day future prices
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceFutureApiDto>> GetFuturePricesAsync(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddFutureExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceFutureApiDto>>(symbol, sort, limit);
    }

    /// <summary>
    /// historic end-of-day future prices in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceFutureApiDto>> GetFuturePricesAsync(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddFutureExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceFutureApiDto>>(symbol, from, to, sort, limit);
    }

    /// <summary>
    /// get the full list of all futures
    /// </summary>
    public async Task<List<FuturesApiDto>> GetFuturesAsync()
    {
        return await _generalAPI.GetFuturesAsync();
    }

    /// <summary>
    /// get historic end-of-day index value for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public async Task<PriceIndexApiDto> GetIndexPriceAsync(string symbol, DateTime? date)
    {
        symbol = AddIndexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPriceAsync<PriceIndexApiDto>(symbol, date);
    }

    /// <summary>
    /// get all-time historic end-of-day index value
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceIndexApiDto>> GetIndexPricesAsync(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddIndexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceIndexApiDto>>(symbol, sort, limit);
    }

    /// <summary>
    /// historic end-of-day index value in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceIndexApiDto>> GetIndexPricesAsync(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        symbol = AddIndexExchange(symbol);
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceIndexApiDto>>(symbol, from, to, sort, limit);
    }

    /// <summary>
    /// get the full list of all indices
    /// </summary>
    public async Task<List<IndicesApiDto>> GetIndicesAsync()
    {
        return await _generalAPI.GetIndicesAsync();
    }

    /// <summary>
    /// get the actual key state (limits, counted datapoints)
    /// </summary>
    public async Task<KeyStateDto> GetKeyStateAsync()
    {
        return await _generalAPI.GetKeyStateAsync();
    }

    /// <summary>
    /// get historic end-of-day price for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public async Task<PriceApiDto> GetPriceAsync(string symbol, DateTime? date)
    {
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPriceAsync<PriceApiDto>(symbol, date);
    }

    /// <summary>
    /// get all-time historic end-of-day prices
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceApiDto>> GetPricesAsync(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceApiDto>>(symbol, sort, limit);
    }

    /// <summary>
    /// historic end-of-day prices in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public async Task<List<PriceApiDto>> GetPricesAsync(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        CheckTickerValid(symbol);
        return await _endOfDayAPI.GetPricesAsync<List<PriceApiDto>>(symbol, from, to, sort, limit);
    }

    public async Task<List<SharesApiDto>> GetSymbolsAsync(string exchange)
    {
        return await _generalAPI.GetSymbolsAsync(exchange);
    }

    /// <summary>
    /// get the full list of all symbols of a defined exchange
    /// </summary>
    /// <param name="exchange">list contains all symbols of the given exchange</param>
    private static void CheckTickerValid(string ticker)
    {
        if ((ticker == string.Empty || !ticker.Contains('.')))
        {
            throw new ArgumentException($"ticker {ticker} invalid.");
        }
    }

    private string AddCryptoExchange(string symbol)
    {
        return symbol.ToLower().Contains(".crypto") ? symbol.ToLower() : $"{symbol}.crypto";
    }

    private string AddForexExchange(string symbol)
    {
        return symbol.ToLower().Contains(".forex") ? symbol.ToLower() : $"{symbol}.forex";
    }

    private string AddFutureExchange(string symbol)
    {
        return symbol.ToLower().Contains(".future") ? symbol.ToLower() : $"{symbol}.future";
    }

    private string AddIndexExchange(string symbol)
    {
        return symbol.ToLower().Contains(".index") ? symbol.ToLower() : $"{symbol}.index";
    }
}