using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQS.Framework.DefaultImp;
using CQS.Framework.DefaultImp.QueryResult;

namespace CQS.Framework.Query
{
    public abstract class QueryResult<TModel> : IQueryResult<TModel>
        where TModel : class
    {
        IQueryResult IQueryResult.Where(Expression<Func<object, bool>> where)
        {
            Expression convertedExpression = Expression.Convert(where.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, where.Parameters
            );

            return Where(finalExpression);
        }

        IQueryResult IQueryResult.Include<TProperty>(Expression<Func<object, TProperty>> include)
        {
            Expression convertedExpression = Expression.Convert(include.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, include.Parameters
            );

            return Include(finalExpression);
        }

        IQueryResult IQueryResult.OrderBy<TKey>(Expression<Func<object, TKey>> orderBy)
        {
            Expression convertedExpression = Expression.Convert(orderBy.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, orderBy.Parameters
            );

            return OrderBy(finalExpression);
        }

        IQueryResult IQueryResult.OrderByDesc<TKey>(Expression<Func<object, TKey>> orderBy)
        {
            Expression convertedExpression = Expression.Convert(orderBy.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, orderBy.Parameters
            );

            return OrderByDesc(finalExpression);
        }

        IQueryResult IQueryResult.Skip(int skip)
        {
            return Skip(skip);
        }

        IQueryResult IQueryResult.Take(int take)
        {
            return Take(take);
        }

        object IQueryResult.First()
        {
            return First();
        }

        public object First(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, first.Parameters
            );

            return First(finalExpression);
        }

        Task<object> IQueryResult.FirstAsync()
        {
            return FirstAsync().ContinueWith(t => (object) t.Result);
        }

        public Task<object> FirstAsync(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, first.Parameters
            );

            return FirstAsync(finalExpression).ContinueWith(t => (object) t.Result);
        }

        object IQueryResult.FirstOrDefault()
        {
            return FirstOrDefault();
        }

        public object FirstOrDefault(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, first.Parameters
            );

            return FirstOrDefault(finalExpression);
        }

        Task<object> IQueryResult.FirstOrDefaultAsync()
        {
            return FirstOrDefaultAsync().ContinueWith(t => (object) t.Result);
        }

        public Task<object> FirstOrDefaultAsync(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, first.Parameters
            );

            return FirstOrDefaultAsync(finalExpression).ContinueWith(t => (object) t.Result);
        }

        object IQueryResult.Single()
        {
            return Single();
        }

        public object Single(Expression<Func<object, bool>> single)
        {
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, single.Parameters
            );

            return Single(finalExpression);
        }

        Task<object> IQueryResult.SingleAsync()
        {
            return SingleAsync().ContinueWith(t => (object) t.Result);
        }

        public Task<object> SingleAsync(Expression<Func<object, bool>> single)
        {
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, single.Parameters
            );

            return SingleAsync(finalExpression).ContinueWith(t => (object) t.Result);
        }

        object IQueryResult.SingleOrDefault()
        {
            return SingleOrDefault();
        }

        public object SingleOrDefault(Expression<Func<object, bool>> single)
        {
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, single.Parameters
            );

            return SingleOrDefault(finalExpression);
        }

        Task<object> IQueryResult.SingleOrDefaultAsync()
        {
            return SingleOrDefaultAsync().ContinueWith(t => (object) t.Result);
        }

        public Task<object> SingleOrDefaultAsync(Expression<Func<object, bool>> single)
        {
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TModel));
            Expression<Func<TModel, bool>> finalExpression = Expression.Lambda<Func<TModel, bool>>
            (
                convertedExpression, single.Parameters
            );

            return SingleOrDefaultAsync(finalExpression).ContinueWith(t => (object) t.Result);
        }

        List<object> IQueryResult.ToList()
        {
            return ToList().Cast<object>().ToList();
        }

        Task<List<object>> IQueryResult.ToListAsync()
        {
            return ToListAsync().ContinueWith(t => t.Result.Cast<object>().ToList());
        }

        public abstract IQueryResult<TModel> Where(Expression<Func<TModel, bool>> where);

        public abstract IQueryResult<TModel> Include<TProperty>(Expression<Func<TModel, TProperty>> include);

        public abstract IQueryResult<TModel> OrderBy<TKey>(Expression<Func<TModel, TKey>> orderBy);

        public abstract IQueryResult<TModel> OrderByDesc<TKey>(Expression<Func<TModel, TKey>> orderBy);

        public abstract IQueryResult<TModel> Skip(int skip);

        public abstract IQueryResult<TModel> Take(int take);

        public abstract TModel First();

        public abstract TModel First(Expression<Func<TModel, bool>> first);

        public abstract Task<TModel> FirstAsync();

        public abstract Task<TModel> FirstAsync(Expression<Func<TModel, bool>> first);

        public abstract TModel FirstOrDefault();

        public abstract TModel FirstOrDefault(Expression<Func<TModel, bool>> first);

        public abstract Task<TModel> FirstOrDefaultAsync();

        public abstract Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> first);

        public abstract TModel Single();

        public abstract TModel Single(Expression<Func<TModel, bool>> single);

        public abstract Task<TModel> SingleAsync();

        public abstract Task<TModel> SingleAsync(Expression<Func<TModel, bool>> single);

        public abstract TModel SingleOrDefault();

        public abstract TModel SingleOrDefault(Expression<Func<TModel, bool>> single);

        public abstract Task<TModel> SingleOrDefaultAsync();

        public abstract Task<TModel> SingleOrDefaultAsync(Expression<Func<TModel, bool>> single);

        public abstract List<TModel> ToList();

        public abstract Task<List<TModel>> ToListAsync();

        public static QueryableQueryResult<TModel> FromQueryable(IQueryable<TModel> query)
        {
            return new QueryableQueryResult<TModel>(query);
        }

        public static FromResultQueryResult<TModel> FromResult(TModel @object)
        {
            return new FromResultQueryResult<TModel>(@object);
        }

        public static FromResultQueryResult<TModel> FromEmptyResult()
        {
            return new FromResultQueryResult<TModel>(null);
        }
    }
}