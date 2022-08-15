using AutoMapper.QueryableExtensions;
using MinimalApiWithMediatr.Common.Models;

namespace Microsoft.EntityFrameworkCore.Utils;

public static class ApplicationDbContextExtensions
{
    public static async Task<TOut[]> ToProjectedArrayAsync<TIn, TOut>(this IQueryable queryable)
    {
        return await queryable.ProjectTo<TOut>(Mapper.Instance!.ConfigurationProvider).ToArrayAsync();
    }
    
    public static async Task<TOut[]> ToProjectedArrayAsync<TIn, TOut>(this IQueryable queryable, CancellationToken cancellationToken)
    {
        return await queryable.ProjectTo<TOut>(Mapper.Instance!.ConfigurationProvider).ToArrayAsync(cancellationToken);
    }
}