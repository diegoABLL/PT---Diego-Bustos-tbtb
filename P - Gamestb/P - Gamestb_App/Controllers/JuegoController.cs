using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P___Gamestb_App.Data;
using P___Gamestb_App.Models;
using P___Gamestb_App.Models.ViewModels;


namespace P___Gamestb_App.Controllers
{
    public class JuegoController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public JuegoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Juego -------------------------------------------------------------------------------------------------
             
        public async Task<IActionResult> Index()
        {
            var viewModel = _context.Juego
                .Include(j => j.Desarrolladora)  // Relación con Desarrolladora
                .ToList();

            return View(viewModel);
        }
      

        // GET: Juego/Search -------------------------------------------------------------------------------------------
        public async Task<IActionResult> Search()
        {
            return View();
        }

        // GET: Juego/SearchResults
        public async Task<IActionResult> SearchResults(String SearchP)
        {
            var viewModel = _context.Juego
            .Include(j => j.Desarrolladora)  // Relación con Desarrolladora
            .ToList();

            return View("index", await _context.Juego
                .Where(j => j.Nombre.StartsWith(SearchP))  // Usar StartsWith en lugar de Contains
                .ToListAsync());
        }

        // GET: Juego/Details/5  -------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juego
                          .Include(j => j.Desarrolladora) 
                          .FirstOrDefaultAsync(j => j.JuegoID == id);
            
            var viewModel = new JuegoDesarrolladoraViewModel
            {
                JuegoID = juego.JuegoID,
                Nombre = juego.Nombre,
                Precio = juego.Precio,
                DesarrolladoraNombre = juego.Desarrolladora?.Nombre // Asignar el nombre del desarrollador
            };

            if (juego == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Juego/Create -------------------------------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juego/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]

        public IActionResult Create(JuegoDesarrolladoraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // En caso de que la validación falle
            }

            // Iniciar una transacción
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Insertar el Desarrollador en la tabla desarrollador
                    var nuevoDesarrollador = new Desarrolladora
                    {
                        Nombre = model.DesarrolladoraNombre
                    };
                    _context.Desarrolladora.Add(nuevoDesarrollador);
                    _context.SaveChanges();

                    // 2. Insertar el Juego en la tabla juego (usando el Id del Desarrollador recién creado)
                    var nuevoJuego = new Juego
                    {
                        Nombre = model.Nombre,
                        Precio = model.Precio,
                        DesarrolladoraID = nuevoDesarrollador.DesarrolladoraID // Aquí usamos el Id del desarrollador recién creado
                    };
                    _context.Juego.Add(nuevoJuego);
                    _context.SaveChanges();

                    // 3. Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest("Error al crear el desarrollador o el juego: " + ex.Message);
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Juego/Edit/5 -------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Usar Include para traer los datos del desarrollador junto con el juego
            var juego = await _context.Juego
                                      .Include(j => j.Desarrolladora) // Cargar el desarrollador
                                      .FirstOrDefaultAsync(j => j.JuegoID == id);

            if (juego == null)
            {
                return NotFound();
            }

            // Mapear los datos al ViewModel
            var viewModel = new JuegoDesarrolladoraViewModel
            {
                JuegoID = juego.JuegoID,
                Nombre = juego.Nombre,
                Precio = juego.Precio,
                DesarrolladoraNombre = juego.Desarrolladora?.Nombre // Asignar el nombre del desarrollador
            };

            // Pasar el ViewModel a la vista
            return View(viewModel);
        }

        // POST: Juego/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(JuegoDesarrolladoraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Retornar la vista con el modelo si hay errores de validación
            }

            // Iniciar una transacción para asegurar la atomicidad
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Buscar el juego en la base de datos incluyendo al desarrollador
                    var juegoExistente = _context.Juego
                                                 .Include(j => j.Desarrolladora)
                                                 .FirstOrDefault(j => j.JuegoID == model.JuegoID);

                    if (juegoExistente == null)
                    {
                        return NotFound("Juego no encontrado");
                    }

                    // 2. Actualizar los datos del desarrollador solo si es necesario
                    if (juegoExistente.Desarrolladora.Nombre != model.DesarrolladoraNombre)
                    {
                        juegoExistente.Desarrolladora.Nombre = model.DesarrolladoraNombre;
                    }

                    // 3. Actualizar los datos del juego
                    juegoExistente.Nombre = model.Nombre;
                    juegoExistente.Precio = model.Precio;

                    // 4. Guardar los cambios en la base de datos
                    _context.SaveChanges();

                    // 5. Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Si algo falla, hacer rollback
                    transaction.Rollback();
                    return BadRequest("Error al editar el juego o desarrollador: " + ex.Message);
                }
            }

            // Redirigir o devolver una respuesta exitosa
            return RedirectToAction("Index");
        }

        // GET: Juego/Delete/5  -------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juego
                                      .Include(j => j.Desarrolladora) // Cargar el desarrollador
                                      .FirstOrDefaultAsync(j => j.JuegoID == id);

            // Mapear los datos al ViewModel
            var viewModel = new JuegoDesarrolladoraViewModel
            {
                JuegoID = juego.JuegoID,
                Nombre = juego.Nombre,
                Precio = juego.Precio,
                DesarrolladoraNombre = juego.Desarrolladora?.Nombre // Asignar el nombre del desarrollador
            };

            if (juego == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juego = await _context.Juego.FindAsync(id);
            if (juego != null)
            { 
                _context.Juego.Remove(juego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
            return _context.Juego.Any(e => e.JuegoID == id);
        }
    }
}
