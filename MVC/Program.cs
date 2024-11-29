using Microsoft.EntityFrameworkCore;
using MVC.Managers;
using MVC.Models;
using MVC.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MarketDB>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Repository>();
builder.Services.AddScoped<IProducts, Beverages>();
builder.Services.AddScoped<IProducts, Fish>();
builder.Services.AddScoped<IProducts, Meat>();
builder.Services.AddScoped<IProducts, Vegetables>();
//builder.Services.AddSession(); // ��������� ��������� ������
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.UseSession(); // �������� ������

app.MapDefaultControllerRoute();
app.Run();
