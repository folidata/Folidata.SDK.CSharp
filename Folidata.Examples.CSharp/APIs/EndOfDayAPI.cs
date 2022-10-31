using Folidata.Contracts;
using Folidata.Utils;

namespace Folidata.Apis;

internal class EndOfDayAPI : FolidataApiBase, IEndOfDayAPI
{
    private static readonly string _endpoint = "eod";

    public EndOfDayAPI(string apiKey, string url = "") : base(apiKey, url)
    {
    }

    public async Task<T> GetPriceAsync<T>(string symbol, DateTime? date)
    {
        var url = _url + _endpoint;
        if (symbol != null) url = AddUrlParameter(url, "symbol", symbol);
        if (date != null) url = AddUrlParameter(url, "date", date?.ToString("yyyy-MM-dd") ?? "");

        return await ExecuteQueryAsync<T>(url);
    }

    public async Task<T> GetPricesAsync<T>(string symbol, DateTime? from, DateTime? to, SortMode sort = SortMode.ASC, int limit = 0)
    {
        var url = _url + _endpoint;
        if (symbol != null) url = AddUrlParameter(url, "symbol", symbol);
        if (from != null) url = AddUrlParameter(url, "from", from?.ToString("yyyy-MM-dd") ?? "");
        if (to != null) url = AddUrlParameter(url, "to", to?.ToString("yyyy-MM-dd") ?? "");
        url = AddUrlParameter(url, "sort", sort);
        url = AddUrlParameter(url, "limit", limit);

        return await ExecuteQueryAsync<T>(url);
    }

    public async Task<T> GetPricesAsync<T>(string symbol, SortMode sort = SortMode.ASC, int limit = 0)
    {
        var url = _url + _endpoint;
        if (symbol != null) url = AddUrlParameter(url, "symbol", symbol);
        url = AddUrlParameter(url, "sort", sort);
        url = AddUrlParameter(url, "limit", limit);

        return await ExecuteQueryAsync<T>(url);
    }
}