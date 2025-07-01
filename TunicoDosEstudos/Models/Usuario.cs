namespace TunicoDosEstudos.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public ICollection<Rotina>? Rotinas { get; set; }
    public virtual PerfilUsuario? PerfilUsuario { get; set; }
}