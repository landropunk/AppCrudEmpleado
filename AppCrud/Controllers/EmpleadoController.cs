using Microsoft.AspNetCore.Mvc;
using AppCrud.Data;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Controllers
{
    /// <summary>
    /// Controlador para gestionar empleados.
    /// </summary>
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDbContext;

        /// <summary>
        /// Constructor para EmpleadoController.
        /// </summary>
        /// <param name="appDbContext">El contexto de la base de datos de la aplicación.</param>
        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Obtiene la lista de empleados.
        /// </summary>
        /// <returns>Una vista con la lista de empleados.</returns>
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);
        }

        /// <summary>
        /// Devuelve la vista para crear un nuevo empleado.
        /// </summary>
        /// <returns>La vista para crear un nuevo empleado.</returns>
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        /// <summary>
        /// Crea un nuevo empleado.
        /// </summary>
        /// <param name="empleado">El empleado a crear.</param>
        /// <returns>Una redirección a la lista de empleados.</returns>
        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        /// <summary>
        /// Devuelve la vista para editar un empleado.
        /// </summary>
        /// <param name="id">El id del empleado a editar.</param>
        /// <returns>La vista para editar un empleado.</returns>
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }

        /// <summary>
        /// Edita un empleado.
        /// </summary>
        /// <param name="empleado">El empleado a editar.</param>
        /// <returns>Una redirección a la lista de empleados.</returns>
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        /// <summary>
        /// Elimina un empleado.
        /// </summary>
        /// <param name="id">El id del empleado a eliminar.</param>
        /// <returns>Una redirección a la lista de empleados.</returns>
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
