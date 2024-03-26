using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;

namespace App.Controllers;

[Authorize]
public class DepartamentosController : Controller
{
    private readonly Contexto _db;

    public DepartamentosController(Contexto db)
    {
        _db = db;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var lista = await _db.Departamentos
            .OrderBy(o => o.Nombre)
            .ToListAsync();

        return View(lista);
    }

    public IActionResult Anadir()
    {
        CarregarViewDatas();
        return View();
    }

    private void CarregarViewDatas(string color = "")
    {
        var listaColores = new string[]{
            "Amarillo",
            "Azul",
            "Naranja",
            "Purpura",
            "Rojo",
            "Verde"
        };

        ViewData["selectColores"] = new SelectList(listaColores, color);
    }

    [HttpPost]
    public async Task<IActionResult> Anadir(Departamento model)
    {
        if (ModelState.IsValid)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        CarregarViewDatas(model.Color);
        return View(model);
    }

    public async Task<IActionResult> Editar(int id)
    {
        var model = await _db.Departamentos
            .FirstOrDefaultAsync(w => w.Id == id);

        CarregarViewDatas(model.Color);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Departamento model)
    {
        if (ModelState.IsValid)
        {
            _db.Update(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        CarregarViewDatas(model.Color);
        return View(model);
    }


    public async Task<IActionResult> Deletar(int id)
    {
        var model = await _db.Departamentos
            .FirstOrDefaultAsync(w => w.Id == id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeletarPost(int id)
    {
        var model = await _db.Departamentos.FindAsync(id);

        _db.Departamentos.Remove(model);

        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
