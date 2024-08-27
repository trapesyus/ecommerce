using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s�n� yap�land�r
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ASP.NET Core Identity'yi ekle
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<YourDbContext>()
    .AddDefaultTokenProviders();

// MVC hizmetlerini ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek pipeline'�n� yap�land�r
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Kimlik do�rulama ve yetkilendirme i�in middleware'i ekle
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
