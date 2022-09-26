using Microsoft.EntityFrameworkCore;
using TrisoleRed.Data.Models;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Services;
using TrisolRed.Web.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfigurationJson>();
builder.Services.AddDbContext<PropertiesContext>
              (item => item.UseSqlServer
              (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IProperties, PropertiesServieses>();

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
