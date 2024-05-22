using Microsoft.EntityFrameworkCore;
using Cafe_website.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CafeContext>(options =>
                //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=cafe;Trusted_Connection=True;TrustServerCertificate=True;"));
                //options.UseSqlServer("Server=146.19.207.159,1433;Database=Cafe;User Id=sa;Password=DbReFoRpm228@;MultipleActiveResultSets=True;"));
options.UseSqlServer("Server=146.19.207.159,1433;Database=Cafe;User Id=sa;Password=DbReFoRpm228@;MultipleActiveResultSets=True;TrustServerCertificate=True;"));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
