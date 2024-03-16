using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using App.Models;
using App.Data;

namespace App.Controllers;

[Authorize]
public class TareasController : Controller
{
    private readonly Contexto _db;

    public TareasController(Contexto db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var lista = await _db.Tareas.OrderBy(o => o.Id).ToListAsync();
        return View(lista);
    }

    public async Task<IActionResult> Detalhes(int? id)
    {
        var model = await _db.Tareas.FindAsync(id);
        return View(model);
    }

    public async Task<IActionResult> Criar()
    {
        await CarregarViewDatas();
        return View();
    }

    private async Task CarregarViewDatas(List<int> tareasDependentes = null, int removerTareaId = 0)
    {
        tareasDependentes ??= new List<int>();

        var tareas = await _db.Tareas
            .AsNoTracking()
            .OrderBy(o => o.Inicio)
            .Select(s => new
            {
                s.Id,
                Nome = $"{s.Responsable} - {s.Titulo} - {s.Inicio:d} ate {s.Fim:d}"
            })
            .ToListAsync();

        if (removerTareaId > 0)
        {
            var t = tareas.SingleOrDefault(s => s.Id == removerTareaId);
            tareas.Remove(t);
        }

        ViewData["selectTareas"] = new MultiSelectList(tareas, "Id", "Nome", tareasDependentes);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(FormTarea model)
    {
        if (ModelState.IsValid)
        {
            var tarea = new Tarea
            {
                Titulo = model.Titulo,
                Responsable = model.Responsable,
                Inicio = model.Inicio,
                Fim = model.Fim
            };

            _db.Add(tarea);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        await CarregarViewDatas();

        return View(ModelState);
    }

    public async Task<IActionResult> Editar(int id)
    {
        var model = await _db.Tareas
            .Where(w => w.Id == id)
            .Select(s => new FormTarea
            {
                Id = s.Id,
                Inicio = s.Inicio,
                Fim = s.Fim,
                Titulo = s.Titulo,
                Responsable = s.Responsable,
                TareasDependentes = s.TareasPais.Select(p => p.Id).ToList()
            })
            .FirstOrDefaultAsync();

        await CarregarViewDatas(model.TareasDependentes, model.Id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(FormTarea model)
    {
        if (ModelState.IsValid)
        {
            var tarea = await _db.Tareas
                .Include(w => w.TareasPais)
                .SingleOrDefaultAsync(s => s.Id == model.Id);

            tarea.Atualizar(model.Titulo, model.Responsable, model.Inicio, model.Fim);

            if (model.TareasDependentes.Any())
            {
                var listadoTareas = await _db.Tareas.Where(w => model.TareasDependentes.Contains(w.Id)).ToListAsync();
                tarea.AtribuirTareasDependentes(listadoTareas);
            }

            _db.Update(tarea);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        await CarregarViewDatas(model.TareasDependentes, model.Id);
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
        var model = await _db.Tareas.FindAsync(id);

        _db.Tareas.Remove(model);

        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
