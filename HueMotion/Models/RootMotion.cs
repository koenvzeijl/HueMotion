using System.Text.Json.Serialization;

namespace HueMotion.Models
{
    public class RootMotion
    {
        [JsonPropertyName("data")]
        public List<MotionData> Data { get; set; } = new List<MotionData>();
    }

    public class MotionData
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("motion")]
        public Motion? Motion { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
    }

    public class Motion
    {
        [JsonPropertyName("motion")]
        public bool Value { get; set; }

        [JsonPropertyName("motion_valid")]
        public bool Valid { get; set; }
    }
}
