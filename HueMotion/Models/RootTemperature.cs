using System.Text.Json.Serialization;

public class RootTemperature
{
    [JsonPropertyName("errors")]
    public List<object> Errors { get; set; } = new List<object>();
    [JsonPropertyName("data")]
    public List<TemperatureData> Data { get; set; } = new List<TemperatureData>();
}

public class TemperatureData
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("temperature")]
    public Temperature? Temperature { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
}

public class Temperature
{
    [JsonPropertyName("temperature")]
    public float Value { get; set; }

    [JsonPropertyName("temperature_valid")]
    public bool Valid { get; set; }
}
