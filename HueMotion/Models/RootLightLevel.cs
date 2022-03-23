using System.Text.Json.Serialization;

public class RootLightLevel
{
    [JsonPropertyName("errors")]
    public List<object> Errors { get; set; } = new List<object>();
    [JsonPropertyName("data")]
    public List<LightLevelData> Data { get; set; } = new List<LightLevelData>();
}

public class LightLevelData
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("id_v1")]
    public string V1Id { get; set; } = "";
    [JsonPropertyName("light")]
    public Light? Light { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
}

public class Light
{
    [JsonPropertyName("light_level")]
    public int Value { get; set; }
    [JsonPropertyName("light_level_valid")]
    public bool Valid { get; set; }
}
