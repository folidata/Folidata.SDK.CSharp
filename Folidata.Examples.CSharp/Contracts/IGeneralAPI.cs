using Folidata.Model.General;

namespace Folidata.Contracts;

/// <summary>
/// general data (symbols, exchanges, cryptos, etc.)
/// </summary>
internal interface IGeneralAPI
{
    /// <summary>
    /// get the full list of all cryptos
    /// </summary>
    public Task<List<CryptosApiDto>> GetCryptosAsync();

    /// <summary>
    /// get the full list of all exchanges
    /// </summary>
    public Task<List<ExchangesApiDto>> GetExchangeAsync();

    /// <summary>
    /// get the full list of all forex pairs
    /// </summary>
    public Task<List<ForexApiDto>> GetForexAsync();

    /// <summary>
    /// get the full list of all futures
    /// </summary>
    public Task<List<FuturesApiDto>> GetFuturesAsync();

    /// <summary>
    /// get the full list of all indices
    /// </summary>
    public Task<List<IndicesApiDto>> GetIndicesAsync();

    /// <summary>
    /// get the actual key state (limits, counted datapoints)
    /// </summary>
    public Task<KeyStateDto> GetKeyStateAsync();

    /// <summary>
    /// get the full list of all symbols of a defined exchange
    /// </summary>
    /// <param name="exchange">list contains all symbols of the given exchange</param>
    public Task<List<SharesApiDto>> GetSymbolsAsync(string exchange);
}