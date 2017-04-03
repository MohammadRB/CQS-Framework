// [07/21/2016 MRB]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp
{
    public class FromResultQueryResult<TEntity, TModel> : QueryResult<TEntity, TModel> 
        where TEntity : class
        where TModel : class
    {
        public TModel Object { get; private set; }

        public FromResultQueryResult(TModel @object)
        {
            Object = @object;
        }

        public override IQueryResult<TEntity, TModel> Where(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TEntity, TModel> Include<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderby)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult< TEntity, TModel > OrderByDesc< TKey >(Expression< Func< TEntity, TKey > > @orderby)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TEntity, TModel> Skip(int skip)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TEntity, TModel> Take(int take)
        {
            throw new NotImplementedException();
        }

        public override TModel First()
        {
            if (Object == null)
            {
                throw new InvalidOperationException();
            }

            return Object;
        }

        public override TModel First(Expression<Func<TEntity, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> FirstAsync()
        {
            return Task.FromResult(First());
        }

        public override Task<TModel> FirstAsync(Expression<Func<TEntity, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override TModel FirstOrDefault()
        {
            return Object;
        }

        public override TModel FirstOrDefault(Expression<Func<TEntity, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> FirstOrDefaultAsync()
        {
            return Task.FromResult(FirstOrDefault());
        }

        public override Task<TModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override TModel Single()
        {
            if (Object == null)
            {
                throw new InvalidOperationException();
            }

            return Object;
        }

        public override TModel Single(Expression<Func<TEntity, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> SingleAsync()
        {
            return Task.FromResult(Single());
        }

        public override Task<TModel> SingleAsync(Expression<Func<TEntity, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override TModel SingleOrDefault()
        {
            return Object;
        }

        public override TModel SingleOrDefault(Expression<Func<TEntity, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> SingleOrDefaultAsync()
        {
            return Task.FromResult(SingleOrDefault());
        }

        public override Task<TModel> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override List<TModel> ToList()
        {
            throw new NotImplementedException();
        }

        public override Task<List<TModel>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
