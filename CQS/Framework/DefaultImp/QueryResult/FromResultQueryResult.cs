// [07/21/2016 MRB]

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.QueryResult
{
    public class FromResultQueryResult<TModel> : QueryResult<TModel>
        where TModel : class
    {
        public TModel Object { get; private set; }

        public FromResultQueryResult(TModel @object)
        {
            Object = @object;
        }

        public override IQueryResult<TModel> Where(Expression<Func<TModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TModel> Include<TProperty>(Expression<Func<TModel, TProperty>> include)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TModel> OrderBy<TKey>(Expression<Func<TModel, TKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult< TModel > OrderByDesc< TKey >(Expression< Func< TModel, TKey > > orderBy)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TModel> Skip(int skip)
        {
            throw new NotImplementedException();
        }

        public override IQueryResult<TModel> Take(int take)
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

        public override TModel First(Expression<Func<TModel, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> FirstAsync()
        {
            return Task.FromResult(First());
        }

        public override Task<TModel> FirstAsync(Expression<Func<TModel, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override TModel FirstOrDefault()
        {
            return Object;
        }

        public override TModel FirstOrDefault(Expression<Func<TModel, bool>> first)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> FirstOrDefaultAsync()
        {
            return Task.FromResult(FirstOrDefault());
        }

        public override Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> first)
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

        public override TModel Single(Expression<Func<TModel, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> SingleAsync()
        {
            return Task.FromResult(Single());
        }

        public override Task<TModel> SingleAsync(Expression<Func<TModel, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override TModel SingleOrDefault()
        {
            return Object;
        }

        public override TModel SingleOrDefault(Expression<Func<TModel, bool>> single)
        {
            throw new NotImplementedException();
        }

        public override Task<TModel> SingleOrDefaultAsync()
        {
            return Task.FromResult(SingleOrDefault());
        }

        public override Task<TModel> SingleOrDefaultAsync(Expression<Func<TModel, bool>> single)
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