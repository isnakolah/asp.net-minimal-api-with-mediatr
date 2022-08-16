using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MinimalApiWithMediatr.Data;

public class Repository : IRepository
{ 
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public IQueryable<T> GetQueryable<T>() 
        where T : BaseEntity
    {
        return _context.Set<T>().AsQueryable();
    }

    public async ValueTask<T?> FindByIdAsync<T>(Guid id) 
        where T : BaseEntity
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!) 
        where T : BaseEntity
    {
        return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync<T>(CancellationToken cancellationToken = default) 
        where T : BaseEntity
    {
        return await _context.Set<T>().CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!) 
        where T : BaseEntity
    {
        return await _context.Set<T>().CountAsync(predicate, cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync<T>(CancellationToken cancellationToken = default!) 
        where T : BaseEntity
    {
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!) 
        where T : BaseEntity
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TOut?> FirstOrDefaultAsync<TIn, TOut>(Expression<Func<TIn, bool>> predicate, CancellationToken cancellationToken) 
        where TIn : BaseEntity 
        where TOut : IMapFrom<TIn>
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> ListAsync<T>() 
        where T : BaseEntity
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> ListAsync<T>(CancellationToken cancellationToken) 
        where T : BaseEntity
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> ListAsync<T>(Expression<Func<T, bool>> predicate) 
        where T : BaseEntity
    {
        return await _context.Set<T>()
            .Where(predicate)
            .ToArrayAsync();
    }
    
    public async Task<IEnumerable<T>> ListAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) 
        where T : BaseEntity
    {
        return await _context.Set<T>()
            .Where(predicate)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IEnumerable<TOut>> ListAsync<TIn, TOut>(CancellationToken cancellationToken = default) 
        where TIn : BaseEntity
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TOut>> ListAsync<TIn, TOut>(Expression<Func<TIn, bool>> predicate, CancellationToken cancellationToken = default)
        where TIn : BaseEntity
    {
        throw new NotImplementedException();
    }

    public void Add<T>(T entity) 
        where T : BaseEntity
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange<T>(params T[] entities)
        where T : BaseEntity
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Update<T>(T entity)
        where T : BaseEntity
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete<T>(T entity)
        where T : BaseEntity
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteRange<T>(params T[] entities)
        where T : BaseEntity
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}