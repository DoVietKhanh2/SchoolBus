//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//   options.Cookie.HttpOnly = true;
//   options.Cookie.IsEssential = true;
//});

//builder.Services.AddControllersWithViews();
//var app = builder.Build();
//app.UseSession();
//app.UseAuthentication();
//app.UseAuthorization();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Index}/{id?}"
//   //pattern: "{controller=User}/{action=Index}/{id?}"
//  );

//app.Run();
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
var app = builder.Build();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();   
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
//pattern: "{controller=Home}/{action=Tranghome}/{id?}"
);
app.Run();
