using Folidata.Contracts;
using Folidata.Model.General;

namespace Folidata.Apis;

internal class GeneralAPI : FolidataApiBase, IGeneralAPI
{
    private static readonly string _endpoint = "general";

    public GeneralAPI(string apiKey, string url = "") : base(apiKey, url)
    {
    }

    public async Task<List<CryptosApiDto>> GetCryptosAsync()
    {
        var url = $"{_url}{_endpoint}/cryptos";
        return await ExecuteQueryAsync<List<CryptosApiDto>>(url);
    }

    public async Task<List<ExchangesApiDto>> GetExchangeAsync()
    {
        var url = $"{_url}{_endpoint}/exchanges";
        return await ExecuteQueryAsync<List<ExchangesApiDto>>(url);
    }

    public async Task<List<ForexApiDto>> GetForexAsync()
    {
        var url = $"{_url}{_endpoint}/forex";
        return await ExecuteQueryAsync<List<ForexApiDto>>(url);
    }

    public async Task<List<FuturesApiDto>> GetFuturesAsync()
    {
        var url = $"{_url}{_endpoint}/futures";
        return await ExecuteQueryAsync<List<FuturesApiDto>>(url);
    }

    public async Task<List<IndicesApiDto>> GetIndicesAsync()
    {
        var url = $"{_url}{_endpoint}/indices";
        return await ExecuteQueryAsync<List<IndicesApiDto>>(url);
    }

    public async Task<KeyStateDto> GetKeyStateAsync()
    {
        var url = $"{_url}{_endpoint}/keystate";

        return await ExecuteQueryAsync<KeyStateDto>(url);
    }

    public async Task<List<SharesApiDto>> GetSymbolsAsync(string exchange)
    {
        var url = $"{_url}{_endpoint}/symbols";
        if (exchange != null) url = AddUrlParameter(url, "exchange", exchange);

        return await ExecuteQueryAsync<List<SharesApiDto>>(url);
    }
}