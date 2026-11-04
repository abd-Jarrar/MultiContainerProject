using CustomerService.Services;
using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "CustomerService:";
});
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        LocalCacheExpiration = TimeSpan.FromSeconds(30),
        Expiration = TimeSpan.FromMinutes(5)
    };
});
builder.Services.AddScoped<global::CustomerService.Services.CustomerService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
