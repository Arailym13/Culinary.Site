using Кулинарный_сайт.Data;
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using Кулинарный_сайт.Repositories;
using Кулинарный_сайт.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CulinaryContext>();
builder.Services.AddScoped<IIngredientsService,IngredientsService>();
builder.Services.AddScoped<IIngredientsRepository, IngredientsRepository>();


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
