var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{Id?}");
app.Run();
