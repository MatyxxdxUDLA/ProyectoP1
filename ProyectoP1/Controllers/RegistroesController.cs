using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoP1.Data;
using ProyectoP1.Models;

namespace ProyectoP1.Controllers
{
	public class RegistroesController : Controller
	{
		private readonly ProyectoP1Context _context;

		public RegistroesController(ProyectoP1Context context)
		{
			_context = context;
		}

		// GET: Registroes
		public async Task<IActionResult> Index()
		{
			var proyectoP1Context = _context.Registro.Include(r => r.Cliente).Include(r => r.Vehiculo);
			return View(await proyectoP1Context.ToListAsync());
		}

		// GET: Registroes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registro = await _context.Registro
				.Include(r => r.Cliente)
				.Include(r => r.Vehiculo)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (registro == null)
			{
				return NotFound();
			}

			return View(registro);
		}


		// GET: Registroes/Create
		public IActionResult Create()
		{
			ViewData["ClienteId"] = new SelectList(_context.Cliente.Select(c => new {
				Id = c.Id,
				Descripcion = $"{c.Cedula} - {c.Nombre} {c.Apellido}"
			}), "Id", "Descripcion");

			ViewData["VehiculoId"] = new SelectList(_context.Vehiculo.Select(v => new {
				Id = v.Id,
				Descripcion = $"{v.Placa} - {v.Modelo}"
			}), "Id", "Descripcion");

			return View();
		}


		// POST: Registroes/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,ClienteId,VehiculoId,Estatus,FechaHora")] Registro registro)
		{
			if (ModelState.IsValid)
			{
				_context.Add(registro);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			// Carga nuevamente los datos para los dropdowns manteniendo la selección actual en caso de error
			ViewData["UserId"] = new SelectList(_context.Cliente.Select(c => new {
				Id = c.Id,
				Descripcion = $"{c.Cedula} - {c.Nombre} {c.Apellido}"
			}), "Id", "Descripcion", registro.ClienteId);

			ViewData["VehiculoId"] = new SelectList(_context.Vehiculo.Select(v => new {
				Id = v.Id,
				Descripcion = $"{v.Placa} - {v.Modelo}"
			}), "Id", "Descripcion", registro.VehiculoId);

			return View(registro);
		}


		// GET: Registroes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registro = await _context.Registro.FindAsync(id);
			if (registro == null)
			{
				return NotFound();
			}
			ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", registro.ClienteId);
			ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "Id", "Id", registro.VehiculoId);
			return View(registro);
		}

		// POST: Registroes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,VehiculoId,Estatus,FechaHora")] Registro registro)
		{
			if (id != registro.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(registro);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RegistroExists(registro.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", registro.ClienteId);
			ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "Id", "Id", registro.VehiculoId);
			return View(registro);
		}

		// GET: Registroes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registro = await _context.Registro
				.Include(r => r.Cliente)
				.Include(r => r.Vehiculo)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (registro == null)
			{
				return NotFound();
			}

			return View(registro);
		}

		// POST: Registroes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var registro = await _context.Registro.FindAsync(id);
			if (registro != null)
			{
				_context.Registro.Remove(registro);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool RegistroExists(int id)
		{
			return _context.Registro.Any(e => e.Id == id);
		}
	}
}
