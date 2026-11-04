using Microsoft.Extensions.Caching.Hybrid;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<global::ProductService.Services.ProductService>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "ProductService:";
    options.Configuration = builder.Configuration.GetConnectionString("Redis");

});
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        LocalCacheExpiration = TimeSpan.FromSeconds(30),
        Expiration = TimeSpan.FromMinutes(5)
    };
});
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
