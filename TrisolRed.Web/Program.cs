using AspNetCoreHero.ToastNotification;
using Microsoft.EntityFrameworkCore;
using TrisoleRed.Data.Models;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Services;
using TrisolRed.Web.Helper;

var builder = WebApplication.CreateBuilder(args);
//;
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<PropertiesContext>
              (item => item.UseSqlServer
              (builder.Configuration.GetConnectionString("DefaultConnection")));

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfigurationJson>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IProperties, PropertiesServieses>();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
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
