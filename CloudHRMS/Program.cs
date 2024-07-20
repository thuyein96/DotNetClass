using CloudHRMS.DAO;
using CloudHRMS.Repositories.Domain;
using CloudHRMS.Services;
using CloudHRMS.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// get the configuration
var config = builder.Configuration;
// register CloudApplicationHRMSDbContext with ConnectionString from appsetting.json
builder.Services.AddDbContext<CloudHRMSApplicationDbContext>(o => o.UseSqlServer(config.GetConnectionString("CloudHRMSConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //register the unit of work for all repositories 
builder.Services.AddTransient<IPositionService, PositionService>(); // register the position domain for CRUD process

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
