using Microsoft.EntityFrameworkCore;
using MVC;
using MVC.Infrastructure;
using MVC.Interfaces;
using MVC.Model.Enams;
using MVC.ServicesUI;
using MVC.ViewModels;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new ArgumentException(nameof(connection));

builder.Services.AddInfrastructure(connection);

builder.Services.AddScoped<IProductsServisUI<ProductViewModel, Products>, ProductService>();
builder.Services.AddScoped<IUsersServiseUI<UserViewModel, UserTypes>, UserService>();
builder.Services.AddScoped<IOrderService<OrderViewModel>, OrderService>();


builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();
app.Run();
