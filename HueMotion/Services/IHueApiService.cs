using HueMotion.Models;

public interface IHueApiService
{
    Task<RootLightLevel> GetLightLevelDataAsync();
    Task<RootMotion> GetMotionDataAsync();
    Task<RootTemperature> GetTemperatureDataAsync();
}