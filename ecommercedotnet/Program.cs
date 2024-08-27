using ecommercedotnet.Abstract;
using ecommercedotnet.Concrete;
using ecommercedotnet.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddControllersWithViews();
// Kimlik doðrulama ve yetkilendirme hizmetlerini ekleyin
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.LoginPath = "/Login/Index";
            options.LogoutPath = "/Login/Logout";
            options.AccessDeniedPath = "/Login/AccessDenied";
        });

// Baðlantý dizesini al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// YourDbContext'i Scoped olarak DI konteynerine kaydet
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
