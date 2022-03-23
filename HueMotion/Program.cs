var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddHttpClient("HueApi", httpClient =>
    {
        httpClient.BaseAddress = new Uri($"https://{builder.Configuration.GetValue<string>("HueApi:BridgeIp")}/clip/v2/resource/");
        httpClient.DefaultRequestHeaders.Add("hue-application-key", builder.Configuration.GetValue<string>("HueApi:ApplicationKey"));
    })
    .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = CertificateValidator.VerifyServerCertificate
    });

builder.Services.AddScoped<IHueApiService, HueApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hue}/{action=MotionSensor}/{id?}");

app.Run();
