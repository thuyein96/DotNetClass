var builder = WebApplication.CreateBuilder(args); // create a single web instance
builder.Services.AddControllersWithViews(); //register all of the Controllers to the middleware
var app = builder.Build(); // hosting for the browser as building process
//map all of the url address of Controllers
// initialize the default route
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
app.MapDefaultControllerRoute();
app.Run(); //run the hosting web to the browser
