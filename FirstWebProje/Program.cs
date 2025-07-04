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
app.UseStaticFiles(); // Genellikle bu sat�r da burada olur, ekleyebilirsiniz.

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets(); // Bu metodun ne yapt���n� biliyorsan�z burada kalabilir.

// --- DO�RU YAPI BURASI ---
// UseEndpoints blo�u olmadan, rotalar� do�rudan app �zerine ekleyin.

// 1. �nce daha spesifik olan Area rotas�
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// 2. Sonra daha genel olan varsay�lan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
// .WithStaticAssets(); // Bu extension metodun ne yapt���n� biliyorsan�z burada kalabilir.


app.Run();