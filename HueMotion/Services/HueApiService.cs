using HueMotion.Models;
using System.Text.Json;

public class HueApiService : IHueApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public HueApiService(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task<RootMotion> GetMotionDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("HueApi");

        var httpResponseMessage = await httpClient.GetAsync("motion");

        httpResponseMessage.EnsureSuccessStatusCode();

        var json = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RootMotion>(json);
    }

    public async Task<RootTemperature> GetTemperatureDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("HueApi");

        var httpResponseMessage = await httpClient.GetAsync("temperature");

        httpResponseMessage.EnsureSuccessStatusCode();

        var json = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RootTemperature>(json);
    }

    public async Task<RootLightLevel> GetLightLevelDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("HueApi");

        var httpResponseMessage = await httpClient.GetAsync("light_level");

        httpResponseMessage.EnsureSuccessStatusCode();

        var json = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RootLightLevel>(json);
    }
}
