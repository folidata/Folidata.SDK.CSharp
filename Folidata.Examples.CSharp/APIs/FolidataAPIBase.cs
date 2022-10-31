using Newtonsoft.Json;

namespace Folidata.Apis;

internal abstract class FolidataApiBase : IDisposable
{
    protected readonly string _apiToken;
    protected readonly string _url = @"https://api.folidata.com/v1/";
    private readonly HttpClient _httpClient;

    public FolidataApiBase(string apiToken, string url = "")
    {
        _apiToken = apiToken;

        if (url != "" && url.Length > 0)
            _url = (url.Substring(url.Length - 1, 1) == "/") ? url : $"{url}/";

        _httpClient = new HttpClient();
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    public async Task<T> ExecuteQueryAsync<T>(string url)
    {
        var finalUrl = AddUrlParameter(url, "key", _apiToken);

        var response = await _httpClient.GetAsync(finalUrl);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API response rrror with status code {response.StatusCode}. Reason: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(content);
        if (result == null)
            throw new NullReferenceException();
        return result;
    }

    protected static string AddUrlParameter(string url, string parameter, object value)
    {
        if (url.Contains('?'))
        {
            url += $"&{parameter}={value}";
        }
        else
        {
            url += $"?{parameter}={value}";
        }
        return url;
    }
}