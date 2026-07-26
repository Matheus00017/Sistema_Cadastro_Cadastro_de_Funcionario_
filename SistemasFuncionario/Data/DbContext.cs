using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasFuncionario.Models;

namespace SistemasFuncionario.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}