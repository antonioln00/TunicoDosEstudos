namespace TunicoDosEstudos.Models;

public class PerfilUsuario
{
    public Guid Id { get; set; }
    public string Bio { get; set; }
    public string UrlFoto { get; set; }
    public Guid? IdUsuario { get; set; }
    public virtual Usuario? Usuario { get; set; }
}