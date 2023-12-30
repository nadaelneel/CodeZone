using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(db =>
{
    db.UseLazyLoadingProxies().UseSqlServer(
        builder.Configuration.GetConnectionString("MyDB"));
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped(typeof(ItemManager));
builder.Services.AddScoped(typeof(StoreManager));
builder.Services.AddScoped(typeof(Store_ItemManager));
builder.Services.AddScoped(typeof(UniteOfWork));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute("Default", "{Controller=Home}/{Action=Index}");

app.Run();
