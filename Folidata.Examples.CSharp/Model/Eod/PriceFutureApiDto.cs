using Newtonsoft.Json;

namespace Folidata.Model.Eod;

public class PriceFutureApiDto
{
    public double Close { get; set; }

    [JsonConverter(typeof(Folidata.Extended.DateOnlyJsonConverter))]
    public DateOnly Date { get; set; }
}