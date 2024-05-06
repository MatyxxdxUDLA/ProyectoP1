using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoP1.Models;

namespace ProyectoP1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string contraseña)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Contrasena == contraseña);

            if (usuario != null)
            {
                // Implementa la lógica de sesión aquí
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email o contraseña incorrectos");
            return View();
        }
    }
}
