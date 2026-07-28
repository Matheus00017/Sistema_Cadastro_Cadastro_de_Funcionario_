using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasFuncionario.Data;
using SistemasFuncionario.Models;

namespace SistemasFuncionario.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FuncionariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(usuario);

            IQueryable<Funcionario> query = _context.Funcionarios.Include(f => f.Departamento);

            if (!roles.Contains("RH_Gerente"))
            {
                query = query.Where(f => f.DepartamentoId == usuario.DepartamentoId);
            }

            var funcionarios = await query.ToListAsync();
            return View(funcionarios);
        }
    }
}