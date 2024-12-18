using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MarketDB>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
//builder.Services.AddSession(); // äîáàâëÿåì ïîääåðæêó ñåññèé
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.UseSession(); // включаем сессии

app.MapDefaultControllerRoute();
app.Run();
