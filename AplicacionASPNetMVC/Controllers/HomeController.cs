using AplicacionASPNetMVC.Datos;
using AplicacionASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AplicacionASPNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDbContext _context;

        public HomeController(AplicationDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        [HttpGet]
        public  IActionResult Crear()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se creó correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var usuario = _context.Usuario.Find(id);
            if(usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se editó correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Borrar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Borrar(Usuario usuario)
        {
           // var usuario = await _context.Usuario.FindAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            TempData["Mensaje"] = "El usuario se borró correctamente";
            return RedirectToAction("Index");
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
}