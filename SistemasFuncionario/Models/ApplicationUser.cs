using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Nome { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
}