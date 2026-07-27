using Microsoft.AspNetCore.Identity;

namespace SistemasFuncionario.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } = null!;
    }
}