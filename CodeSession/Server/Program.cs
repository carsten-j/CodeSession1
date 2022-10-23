using CodeSession.Server.Controllers;
using CodeSession.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
//o =>
//{
//    o.ResponseCompressionLevel = CompressionLevel.Optimal;
//    o.ResponseCompressionAlgorithm = "gzip";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<WeatherForecastGrpcService>();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
