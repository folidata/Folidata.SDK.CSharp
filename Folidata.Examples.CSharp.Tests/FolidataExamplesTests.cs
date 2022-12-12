namespace Folidata.Examples.CSharp.Tests;

public class Tests
{
    private readonly string _symbol = "AAPL.US";
    private FolidataApi _folidataApi;
    private string _key = "";

    [Test]
    public async Task Cryptos()
    {
        var result = await _folidataApi.GetCryptosAsync();
        Assert.That(result, Has.Count.GreaterThan(50));
    }

    [Test]
    public async Task Exchanges()
    {
        var result = await _folidataApi.GetExchangeAsync();
        Assert.That(result, Has.Count.GreaterThan(50));
    }

    [Test]
    public async Task Forex()
    {
        var result = await _folidataApi.GetForexAsync();
        Assert.That(result, Has.Count.GreaterThan(50));
    }


    [Test]
    public async Task GetEodAllTime()
    {
        var result = await _folidataApi.GetPricesAsync(_symbol);
        Assert.That(result, Has.Count.GreaterThan(100));
    }

    [Test]
    public async Task GetEodCrypto()
    {
        var symbol = "SHIB-USD";
        var result = await _folidataApi.GetCryptoPricesAsync(symbol);
        Assert.That(result, Has.Count.GreaterThan(100));
        var limit = await _folidataApi.GetCryptoPricesAsync(symbol, new DateTime(2022, 01, 02), null, Utils.SortMode.ASC, 100);
        Assert.That(limit, Has.Count.EqualTo(100));
        var singelDay = await _folidataApi.GetCryptoPriceAsync(symbol, new DateTime(2022, 01, 02));
        Assert.That(singelDay.Close, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetEodForex()
    {
        var symbol = "USDEUR";
        var result = await _folidataApi.GetForexPricesAsync(symbol);
        Assert.That(result, Has.Count.GreaterThan(100));
        var limit = await _folidataApi.GetForexPricesAsync(symbol, new DateTime(2022, 01, 02), null, Utils.SortMode.ASC, 100);
        Assert.That(limit, Has.Count.EqualTo(100));
        var singelDay = await _folidataApi.GetForexPriceAsync(symbol, new DateTime(2022, 01, 02));
        Assert.That(singelDay.Close, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetEodIndex()
    {
        var symbol = "GDAXP";
        var result = await _folidataApi.GetIndexPricesAsync(symbol);
        Assert.That(result, Has.Count.GreaterThan(100));
        var limit = await _folidataApi.GetIndexPricesAsync(symbol, new DateTime(2022, 01, 02), null, Utils.SortMode.ASC, 100);
        Assert.That(limit, Has.Count.EqualTo(100));
        var singelDay = await _folidataApi.GetIndexPriceAsync(symbol, new DateTime(2022, 01, 02));
        Assert.That(singelDay.Close, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetEodSpecificDate()
    {
        // defined timerange
        var result = await _folidataApi.GetPriceAsync(_symbol, new DateTime(2021, 01, 02));
        Assert.That(result.Close, Is.GreaterThan(0));
        Assert.That(result.Date.Day == 2 && result.Date.Month == 1 && result.Date.Year == 2021, Is.True);
    }

    [Test]
    public async Task GetEodTimeRange()
    {
        // defined timerange
        var result = await _folidataApi.GetPricesAsync(_symbol, new DateTime(2021, 01, 02), new DateTime(2022, 01, 01));
        Assert.That(result, Has.Count.GreaterThan(200));

        // until now
        result = await _folidataApi.GetPricesAsync(_symbol, new DateTime(2021, 01, 02), null);
        Assert.That(result, Has.Count.GreaterThan(400));
        Assert.That(result[0].Date.Year, Is.EqualTo(2021));

        // sort desc
        result = await _folidataApi.GetPricesAsync(_symbol, new DateTime(2021, 01, 02), new DateTime(2022, 06, 01), Utils.SortMode.DESC);
        Assert.That(result[0].Date.Year, Is.EqualTo(2022));

        // limit
        result = await _folidataApi.GetPricesAsync(_symbol, new DateTime(2021, 01, 02), null, Utils.SortMode.ASC, 100);
        Assert.That(result.Count, Is.EqualTo(100));

        // no limit
        result = await _folidataApi.GetPricesAsync(_symbol, new DateTime(2021, 01, 02), null, Utils.SortMode.ASC, 0);
        Assert.That(result, Has.Count.GreaterThan(400));
    }

    [Test]
    public async Task Indices()
    {
        var result = await _folidataApi.GetIndicesAsync();
        Assert.That(result, Has.Count.GreaterThan(50));
    }

    [Test]
    public async Task KeyState()
    {
        var result = await _folidataApi.GetKeyStateAsync();
        var montlyCnt = result.MontlyCnt;

        await _folidataApi.GetExchangeAsync();

        var result1 = await _folidataApi.GetKeyStateAsync();
        Assert.That(result1.MontlyCnt, Is.GreaterThan(0));
        Assert.That(montlyCnt, Is.EqualTo((result1.MontlyCnt - 1)));
    }

    [SetUp]
    public void Setup()
    {
        try
        {
            _key = File.ReadAllText(@"D:/Downloads/key.txt");
        }
        catch
        {
            throw;
        }

        _folidataApi = new FolidataApi(_key);
    }

    [Test]
    public async Task Symbols()
    {
        var result = await _folidataApi.GetSymbolsAsync("US");
        Assert.That(result, Has.Count.GreaterThan(50));
    }

    [Test]
    public void WrongSymbol()
    {
        Assert.ThrowsAsync<ArgumentException>(async () => await _folidataApi.GetPriceAsync("AAPL", new DateTime(2021, 01, 02)));
    }
}