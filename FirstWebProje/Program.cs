using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddMvc(Config => { var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    Config.Filters.Add(new AuthorizeFilter(policy)); });
builder.Services.AddMvc();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/AdminLogin/Index/"; });
builder.Services.ConfigureApplicationCookie(options => { options.Cookie.HttpOnly = true; options.ExpireTimeSpan = TimeSpan.FromMinutes(100);   options.AccessDeniedPath = "/ErroPage/Index/";    options.LoginPath="/Writer/Login/Index/"; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Genellikle bu satır da burada olur, ekleyebilirsiniz.

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets(); // Bu metodun ne yaptığını biliyorsanız burada kalabilir.


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// 2. Sonra daha genel olan varsayılan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
// .WithStaticAssets(); // Bu extension metodun ne yaptığını biliyorsanız burada kalabilir.


app.Run();