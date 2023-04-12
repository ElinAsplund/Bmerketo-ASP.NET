using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Identity;
using Bmerketo_WebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
