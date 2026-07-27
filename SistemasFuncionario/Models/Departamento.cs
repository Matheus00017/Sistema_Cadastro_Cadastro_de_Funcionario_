namespace SistemasFuncionario.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Funcionario> Funcionarios { get; set; } = new();
    }
}