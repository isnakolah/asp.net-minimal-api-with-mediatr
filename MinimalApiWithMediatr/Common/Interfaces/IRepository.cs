using System.Linq.Expressions;
using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Common.Interfaces;

public interface IRepository
{
    IQueryable<T> GetQueryable<T>() 
        where T : BaseEntity;

    ValueTask<T?> FindByIdAsync<T>(Guid id) 
        where T : BaseEntity;

    Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!) 
        where T : BaseEntity;

    Task<int> CountAsync<T>(CancellationToken cancellationToken = default!) 
        where T : BaseEntity;

    Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!)
        where T : BaseEntity;

    Task<T?> FirstOrDefaultAsync<T>(CancellationToken cancellationToken = default!)
        where T : BaseEntity;

    Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default!)
        where T : BaseEntity;

    Task<TOut?> FirstOrDefaultAsync<TIn, TOut>(Expression<Func<TIn, bool>> predicate, CancellationToken cancellationToken)
        where TIn : BaseEntity
        where TOut : IMapFrom<TIn>;

    Task<IEnumerable<T>> ListAsync<T>()
        where T : BaseEntity;

    Task<IEnumerable<T>> ListAsync<T>(CancellationToken cancellationToken)
        where T : BaseEntity;
    
    Task<IEnumerable<T>> ListAsync<T>(Expression<Func<T, bool>> predicate)
        where T : BaseEntity;

    Task<IEnumerable<T>> ListAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        where T : BaseEntity;

    Task<IEnumerable<TOut>> ListAsync<TIn, TOut>(CancellationToken cancellationToken = default!)
        where TIn : BaseEntity;
    
    Task<IEnumerable<TOut>> ListAsync<TIn, TOut>(Expression<Func<TIn, bool>> predicate, CancellationToken cancellationToken = default!)
        where TIn : BaseEntity;

    void Add<T>(T entity)
        where T : BaseEntity;

    void AddRange<T>(params T[] entities)
        where T : BaseEntity;

    void Update<T>(T entity)
        where T : BaseEntity;

    void Delete<T>(T entity)
        where T : BaseEntity;

    void DeleteRange<T>(params T[] entities)
        where T : BaseEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}