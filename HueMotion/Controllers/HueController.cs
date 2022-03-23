using Microsoft.AspNetCore.Mvc;
using HueMotion.Models;

public class HueController : Controller
{
    public IHueApiService _hueApiService;

    public HueController(IHueApiService hueApiService)
    {
        _hueApiService = hueApiService;
    }

    public async Task<IActionResult> MotionSensor()
    {
        var model = await CreateHueSensorDetailsViewModelAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<JsonResult> GetHueMotionSensorDetails()
    {
        var model = await CreateHueSensorDetailsViewModelAsync();
        return Json(model);
    }

    private async Task<MotionSensorDetailsViewModel> CreateHueSensorDetailsViewModelAsync()
    {
        var temperature = await _hueApiService.GetTemperatureDataAsync();
        var motion = await _hueApiService.GetMotionDataAsync();
        var lightLevel = await _hueApiService.GetLightLevelDataAsync();

        return new MotionSensorDetailsViewModel
        {
            Temperature = temperature.Data.FirstOrDefault()?.Temperature?.Value ?? 0,
            Motion = motion.Data.FirstOrDefault()?.Motion?.Value ?? false,
            LightLevel = lightLevel.Data.FirstOrDefault()?.Light?.Value ?? 0,
        };
    }
}
