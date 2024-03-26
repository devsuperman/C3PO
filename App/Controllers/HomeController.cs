using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Diagnostics;
using App.Models;
using App.Data;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Contexto _db;
    public HomeController(ILogger<HomeController> logger, Contexto db)
    {
        _logger = logger;
        _db = db;
    }

    
    public IActionResult Entrar() => View();


    [HttpPost]
    public async Task<IActionResult> Entrar(string senha, string returnUrl)
    {
        if (senha != "8318")
            return View();

        await Logar();

        if (!string.IsNullOrEmpty(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index");
    }

    private async Task Logar()
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Tiago"),
                new Claim(ClaimTypes.NameIdentifier, "Tiago")
            };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
        var authProperties = new AuthenticationProperties { IsPersistent = true };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimPrincipal,
            authProperties);
    }


    public async Task<IActionResult> Index()
    {
        var tasks = await _db.Tareas
            .AsNoTracking()
            .OrderBy(o => o.Inicio)
            .Select(s => new TaskGantt
            {
                Id = s.Id.ToString(),
                Name = $"{s.Departamento.Nombre} - {s.Titulo}",
                Start = s.Inicio.ToString("yyyy-MM-dd"),
                End = s.Fim.ToString("yyyy-MM-dd"),
                Progress = 0,
                Dependencies = string.Join(", ", s.TareasPais.Select(p => p.Id.ToString()).ToArray()),
                Custom_class = s.Departamento.Color
            })
            .ToListAsync();

        return View(tasks);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
