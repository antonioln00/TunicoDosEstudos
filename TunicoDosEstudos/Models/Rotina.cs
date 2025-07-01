namespace TunicoDosEstudos.Models;

public class Rotina
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public string Observacao { get; set; }
    public Guid IdUsuario { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public ICollection<Tarefa>? Tarefas { get; set; }
}
