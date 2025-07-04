using BusinessLayer.ValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Genellikle bu satýr da burada olur, ekleyebilirsiniz.

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets(); // Bu metodun ne yaptýðýný biliyorsanýz burada kalabilir.

// --- DOÐRU YAPI BURASI ---
// UseEndpoints bloðu olmadan, rotalarý doðrudan app üzerine ekleyin.

// 1. Önce daha spesifik olan Area rotasý
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// 2. Sonra daha genel olan varsayýlan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
// .WithStaticAssets(); // Bu extension metodun ne yaptýðýný biliyorsanýz burada kalabilir.


app.Run();