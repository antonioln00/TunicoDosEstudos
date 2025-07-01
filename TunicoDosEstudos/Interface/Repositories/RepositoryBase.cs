using Microsoft.EntityFrameworkCore;

namespace TunicoDosEstudos.Interface.Repositories;

public class RepositoryBase<TEntity>(ApplicationDbContext context) : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context = context;
    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await _context.Set<TEntity>().FindAsync(id);

    public async Task AddAsync(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;

    public void AddRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}