using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.DefaultImp;
using CQS.Framework.Repository;

namespace CQS.Framework.Query
{
    public abstract class QueryResult<TEntity, TModel> : IQueryResult<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        IQueryResult IQueryResult.Where(Expression<Func<object, bool>> where)
        {
            Expression convertedExpression = Expression.Convert(where.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, where.Parameters
                );

            return Where(finalExpression);
        }

        IQueryResult IQueryResult.Include<TProperty>(Expression<Func<object, TProperty>> include)
        {
            Expression convertedExpression = Expression.Convert(include.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, include.Parameters
                );

            return Include(finalExpression);
        }

        IQueryResult IQueryResult.OrderBy<TKey>(Expression<Func<object, TKey>> orderby)
        {
            Expression convertedExpression = Expression.Convert(orderby.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, orderby.Parameters
                );

            return OrderBy(finalExpression);
        }

        IQueryResult IQueryResult.OrderByDesc<TKey>(Expression<Func<object, TKey>> orderby)
        {
            Expression convertedExpression = Expression.Convert(orderby.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, orderby.Parameters
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
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, first.Parameters
                );

            return First(finalExpression);
        }

        Task<object> IQueryResult.FirstAsync()
        {
            return FirstAsync().ContinueWith(t => (object)t.Result);
        }
        
        public Task<object> FirstAsync(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
                (
                    convertedExpression, first.Parameters
                );

            return FirstOrDefault(finalExpression);
        }

        Task<object> IQueryResult.FirstOrDefaultAsync()
        {
            return FirstOrDefaultAsync().ContinueWith(t => (object)t.Result);
        }

        public Task<object> FirstOrDefaultAsync(Expression<Func<object, bool>> first)
        {
            Expression convertedExpression = Expression.Convert(first.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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
            Expression convertedExpression = Expression.Convert(single.Body, typeof(TEntity));
            Expression<Func<TEntity, bool>> finalExpression = Expression.Lambda<Func<TEntity, bool>>
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

        public abstract IQueryResult<TEntity, TModel> Where(Expression<Func<TEntity, bool>> where);

        public abstract IQueryResult<TEntity, TModel> Include<TProperty>(Expression<Func<TEntity, TProperty>> include);

        public abstract IQueryResult<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderby);

        public abstract IQueryResult<TEntity, TModel> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> orderby);

        public abstract IQueryResult<TEntity, TModel> Skip(int skip);

        public abstract IQueryResult<TEntity, TModel> Take(int take);

        public abstract TModel First();

        public abstract TModel First(Expression<Func<TEntity, bool>> first);

        public abstract Task<TModel> FirstAsync();

        public abstract Task<TModel> FirstAsync(Expression<Func<TEntity, bool>> first);

        public abstract TModel FirstOrDefault();

        public abstract TModel FirstOrDefault(Expression<Func<TEntity, bool>> first);

        public abstract Task<TModel> FirstOrDefaultAsync();

        public abstract Task<TModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> first);

        public abstract TModel Single();

        public abstract TModel Single(Expression<Func<TEntity, bool>> single);

        public abstract Task<TModel> SingleAsync();

        public abstract Task<TModel> SingleAsync(Expression<Func<TEntity, bool>> single);

        public abstract TModel SingleOrDefault();

        public abstract TModel SingleOrDefault(Expression<Func<TEntity, bool>> single);

        public abstract Task<TModel> SingleOrDefaultAsync();

        public abstract Task<TModel> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> single);

        public abstract List<TModel> ToList();

        public abstract Task<List<TModel>> ToListAsync();

        public static RepositoryQueryResult<TEntity, TModel> FromRepository(IReadRepository< TEntity > readRepository, Func< TEntity, TModel > mappingFunc)
        {
            return new RepositoryQueryResult< TEntity, TModel >(readRepository, mappingFunc);
        }

        public static FromResultQueryResult< TEntity, TModel > FromResult(TModel @object)
        {
            return new FromResultQueryResult< TEntity, TModel >(@object);
        }

        public static FromResultQueryResult< TEntity, TModel > FromEmptyResult()
        {
            return new FromResultQueryResult< TEntity, TModel >(null);
        }
    }
}
