using Microsoft.EntityFrameworkCore;
using App.Extensions;
using App.Data;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { ContentRootPath = AppContext.BaseDirectory });

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options =>
    options.UseNpgsql(ConnectionHelper.GetConnectionString(builder.Configuration)));

var portVar = Environment.GetEnvironmentVariable("PORT");

if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(port);
    });
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.UsarCulturaEspecifica("es-ES");
var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
