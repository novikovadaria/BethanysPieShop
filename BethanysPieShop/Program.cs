using BethanysPieShop.Models;
using BethanysPieShop.MyDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp=>ShoppingCart.GetCard(sp));

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection")));


builder.Services.AddSession(); 
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseSession();

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

DbInitializer.Seed(app);

app.Run();
