using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Query
{
    public interface IQueryResult
    {
        IQueryResult Where(Expression<Func<object, bool>> where);

        IQueryResult Include<TProperty>(Expression<Func<object, TProperty>> include);

        IQueryResult OrderBy<TKey>(Expression<Func<object, TKey>> orderby);

        IQueryResult OrderByDesc<TKey>(Expression<Func<object, TKey>> orderby);

        IQueryResult Skip(int skip);

        IQueryResult Take(int take);

        object First();

        object First(Expression<Func<object, bool>> first);

        Task<object> FirstAsync();

        Task<object> FirstAsync(Expression<Func<object, bool>> first);

        object FirstOrDefault();

        object FirstOrDefault(Expression<Func<object, bool>> first);

        Task<object> FirstOrDefaultAsync();

        Task<object> FirstOrDefaultAsync(Expression<Func<object, bool>> first);

        object Single();

        object Single(Expression<Func<object, bool>> single);

        Task<object> SingleAsync();

        Task<object> SingleAsync(Expression<Func<object, bool>> single);

        object SingleOrDefault();

        object SingleOrDefault(Expression<Func<object, bool>> single);

        Task<object> SingleOrDefaultAsync();

        Task<object> SingleOrDefaultAsync(Expression<Func<object, bool>> single);

        List<object> ToList();

        Task<List<object>> ToListAsync();
    }

    public interface IQueryResult<TEntity, TModel> : IQueryResult
        where TEntity : class
        where TModel : class
    {
        IQueryResult<TEntity, TModel> Where(Expression<Func<TEntity, bool>> where);

        IQueryResult<TEntity, TModel> Include<TProperty>(Expression<Func<TEntity, TProperty>> include);

        IQueryResult<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderby);

        IQueryResult<TEntity, TModel> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> orderby);

        IQueryResult<TEntity, TModel> Skip(int skip);

        IQueryResult<TEntity, TModel> Take(int take);

        TModel First();

        TModel First(Expression<Func<TEntity, bool>> first);

        Task<TModel> FirstAsync();

        Task<TModel> FirstAsync(Expression<Func<TEntity, bool>> first);

        TModel FirstOrDefault();

        TModel FirstOrDefault(Expression<Func<TEntity, bool>> first);

        Task<TModel> FirstOrDefaultAsync();

        Task<TModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> first);

        TModel Single();

        TModel Single(Expression<Func<TEntity, bool>> single);

        Task<TModel> SingleAsync();

        Task<TModel> SingleAsync(Expression<Func<TEntity, bool>> single);

        TModel SingleOrDefault();

        TModel SingleOrDefault(Expression<Func<TEntity, bool>> single);

        Task<TModel> SingleOrDefaultAsync();

        Task<TModel> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> single);

        List<TModel> ToList();

        Task<List<TModel>> ToListAsync();
    }
}
