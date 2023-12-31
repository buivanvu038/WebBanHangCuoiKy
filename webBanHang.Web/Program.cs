using webBanHang.Web.Services.Interfaces;
using webBanHang.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Create separate HttpClients for IProduct and IOrderService
builder.Services.AddHttpClient<IProduct, ProductService>(c =>
    c.BaseAddress = new Uri("https://localhost:7263/"));

builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri("https://localhost:7263/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
