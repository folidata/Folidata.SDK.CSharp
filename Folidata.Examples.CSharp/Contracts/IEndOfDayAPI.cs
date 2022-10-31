using Folidata.Utils;

namespace Folidata.Contracts;

/// <summary>
/// end-of-day API for all asset types (shares, cryptos, forex, index, futures)
/// </summary>
internal interface IEndOfDayAPI
{
    /// <summary>
    /// get historic end-of-day prices for a defined day
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="date">day of the end-of-day price query.</param>
    /// <returns></returns>
    public Task<T> GetPriceAsync<T>(string symbol, DateTime? date);

    /// <summary>
    /// historic end-of-day prices in a defined time range
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="from">date from</param>
    /// <param name="to">date to</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public Task<T> GetPricesAsync<T>(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0);

    /// <summary>
    /// get all-time historic end-of-day prices
    /// </summary>
    /// <param name="symbol">symbol with exchange: {symbole}.{exchangeCode} (AAPL.US)</param>
    /// <param name="sort">sort direction of the result.</param>
    /// <param name="limit">result is limited to this number. 0 = infinity</param>
    /// <returns></returns>
    public Task<T> GetPricesAsync<T>(string symbol, SortMode sort = SortMode.ASC, int limit = 0);
}