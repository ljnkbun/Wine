using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Read Configuration from appSettings
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();
builder.Services.AddJob();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configurePolicy =>
    {
        configurePolicy.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
    });
});


builder.Services.AddControllersWithViews().AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WineContext>();
    db.Database.Migrate();
}


app.Run();
