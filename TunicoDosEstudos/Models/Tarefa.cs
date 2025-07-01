namespace TunicoDosEstudos.Models;

public class Tarefa
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public string Observacao { get; set; }
    public bool Concluido { get; set; }
    public Guid IdRotina { get; set; }
    public virtual Rotina? Rotina { get; set; }
}
