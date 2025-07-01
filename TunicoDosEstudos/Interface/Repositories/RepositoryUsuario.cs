
using TunicoDosEstudos.Models;

namespace TunicoDosEstudos.Interface.Repositories;

public class RepositoryUsuario(ApplicationDbContext context) : RepositoryBase<Usuario>(context)
{
}