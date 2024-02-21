using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;

namespace App.Controllers
{
    public class TareasController : Controller
    {
        private readonly Contexto _db;

        public TareasController(Contexto db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _db.Tareas.ToListAsync();
            return View(lista);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            var model = await _db.Tareas.FindAsync(id);
            return View(model);
        }

        public IActionResult Criar() => View();
        

        [HttpPost]
        public async Task<IActionResult> Criar(Tarea model)
        {
            if (ModelState.IsValid)
            {
                _db.Add(model);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(ModelState);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var model = await _db.Tareas.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Tarea model)
        {

            if (ModelState.IsValid)
            {
                _db.Update(model);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

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
}
