using BlazorApp.MiddleWare;
using Blazored.Toast;
using HW2OnlineShop;
using HW2OnlineShop.Time;
using HWShop_ASP.net.Data;
using HWShop_ASP.net.Product;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IRealTime, RealTime>();
builder.Services.AddScoped<IProductCatalog, ProductCatalog>();
builder.Services.AddSingleton<IBasket, Basket>();
builder.Services.AddDbContext<AppDbContext>(
   options => options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<RequestLogger>();
app.UseMiddleware<ResponseLogger>();
app.Use(CheckBrowser.CheckerBrowser);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
