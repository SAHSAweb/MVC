using Microsoft.EntityFrameworkCore;
using MVC.Infrastructure;
using MVC.Interfaces;
using MVC.Model;
using MVC.Model.Enams;
using MVC.ServicesUI;
using MVC.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new ArgumentException(nameof(connection));

builder.Services.AddInfrastructure(connection);

builder.Services.AddScoped<IProductsServisUI<ProductViewModel, Products>, ProductService>();
builder.Services.AddScoped<IUsersServiseUI<UserViewModel, UserTypes>, UserService>();

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();
app.Run();
