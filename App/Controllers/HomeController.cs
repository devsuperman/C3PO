using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> Index()
    {
        var tasks = await _db.Tareas
            .AsNoTracking()
            .OrderBy(o => o.Inicio)
            .Select(s => new TaskGantt
            {
                Id = s.Id.ToString(),
                Name = $"{s.Responsable} - {s.Titulo}",
                Start = s.Inicio.ToString("yyyy-MM-dd"),
                End = s.Fim.ToString("yyyy-MM-dd"),
                Progress = 100,
                Dependencies = string.Join(", ", s.TareasPais.Select(p=>p.Id.ToString()).ToArray())
            })
            .ToListAsync();

        return View(tasks);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
