using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CQS.Framework.Query
{
    public interface IQueryResult
    {
        IQueryResult Where(Expression<Func<object, bool>> where);

        IQueryResult Include<TProperty>(Expression<Func<object, TProperty>> include);

        IQueryResult OrderBy<TKey>(Expression<Func<object, TKey>> orderBy);

        IQueryResult OrderByDesc<TKey>(Expression<Func<object, TKey>> orderBy);

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

    public interface IQueryResult<TModel> : IQueryResult
        where TModel : class
    {
        IQueryResult<TModel> Where(Expression<Func<TModel, bool>> where);

        IQueryResult<TModel> Include<TProperty>(Expression<Func<TModel, TProperty>> include);

        IQueryResult<TModel> OrderBy<TKey>(Expression<Func<TModel, TKey>> orderBy);

        IQueryResult<TModel> OrderByDesc<TKey>(Expression<Func<TModel, TKey>> orderBy);

        IQueryResult<TModel> Skip(int skip);

        IQueryResult<TModel> Take(int take);

        TModel First();

        TModel First(Expression<Func<TModel, bool>> first);

        Task<TModel> FirstAsync();

        Task<TModel> FirstAsync(Expression<Func<TModel, bool>> first);

        TModel FirstOrDefault();

        TModel FirstOrDefault(Expression<Func<TModel, bool>> first);

        Task<TModel> FirstOrDefaultAsync();

        Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> first);

        TModel Single();

        TModel Single(Expression<Func<TModel, bool>> single);

        Task<TModel> SingleAsync();

        Task<TModel> SingleAsync(Expression<Func<TModel, bool>> single);

        TModel SingleOrDefault();

        TModel SingleOrDefault(Expression<Func<TModel, bool>> single);

        Task<TModel> SingleOrDefaultAsync();

        Task<TModel> SingleOrDefaultAsync(Expression<Func<TModel, bool>> single);

        List<TModel> ToList();

        Task<List<TModel>> ToListAsync();
    }
}