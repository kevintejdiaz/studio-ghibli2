using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projectoFinalV2.Data;
using projectoFinalV2.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Resto de servicios
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3) Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4) Ruteo MVC por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

// 5) Seeding de datos: se ejecuta una sola vez al arrancar, sin bloquear el pipeline
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.Run();
