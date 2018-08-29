// [07/22/2016 MRB]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.QueryResult
{
    public class QueryableQueryResult<TModel> : QueryResult<TModel>
        where TModel : class
    {
        public QueryableQueryResult(IQueryable<TModel> query)
        {
            _currentQuery = query;
        }

        public override IQueryResult<TModel> Where(Expression<Func<TModel, bool>> where)
        {
            var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.Where(where));
            return newQueryBuilder;
        }

        public override IQueryResult<TModel> Include<TProperty>(Expression<Func<TModel, TProperty>> include)
        {
            throw new NotImplementedException();
            //var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.Include(include));
            //return newQueryBuilder;
        }

        public override IQueryResult<TModel> OrderBy<TKey>(Expression<Func<TModel, TKey>> orderBy)
        {
            var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.OrderBy(orderBy));
            return newQueryBuilder;
        }

        public override IQueryResult<TModel> OrderByDesc<TKey>(Expression<Func<TModel, TKey>> orderBy)
        {
            var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.OrderByDescending(orderBy));
            return newQueryBuilder;
        }

        public override IQueryResult<TModel> Skip(int skip)
        {
            var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.Skip(skip));
            return newQueryBuilder;
        }

        public override IQueryResult<TModel> Take(int take)
        {
            var newQueryBuilder = new QueryableQueryResult<TModel>(_currentQuery.Take(take));
            return newQueryBuilder;
        }

        public override TModel First()
        {
            var model = _currentQuery.First();
            return model;
        }

        public override TModel First(Expression<Func<TModel, bool>> first)
        {
            var model = _currentQuery.First(first);
            return model;
        }

        public override Task<TModel> FirstAsync()
        {
            throw new NotImplementedException();
            //return Task.Run(() => First());
        }

        public override Task<TModel> FirstAsync(Expression<Func<TModel, bool>> first)
        {
            throw new NotImplementedException();
            //return Task.Run(() => First(first));
        }

        public override TModel FirstOrDefault()
        {
            var model = _currentQuery.FirstOrDefault();
            return model;
        }

        public override TModel FirstOrDefault(Expression<Func<TModel, bool>> first)
        {
            var model = _currentQuery.FirstOrDefault(first);
            return model;
        }

        public override Task<TModel> FirstOrDefaultAsync()
        {
            throw new NotImplementedException();
            //return Task.Run(() => FirstOrDefault());
        }

        public override Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> first)
        {
            throw new NotImplementedException();
            //return Task.Run(() => FirstOrDefault(first));
        }

        public override TModel Single()
        {
            var model = _currentQuery.Single();
            return model;
        }

        public override TModel Single(Expression<Func<TModel, bool>> single)
        {
            var model = _currentQuery.Single(single);
            return model;
        }

        public override Task<TModel> SingleAsync()
        {
            throw new NotImplementedException();
            //return Task.Run(() => Single());
        }

        public override Task<TModel> SingleAsync(Expression<Func<TModel, bool>> single)
        {
            throw new NotImplementedException();
            //return Task.Run(() => Single(single));
        }

        public override TModel SingleOrDefault()
        {
            var model = _currentQuery.FirstOrDefault();
            return model;
        }

        public override TModel SingleOrDefault(Expression<Func<TModel, bool>> single)
        {
            var model = _currentQuery.FirstOrDefault(single);
            return model;
        }

        public override Task<TModel> SingleOrDefaultAsync()
        {
            throw new NotImplementedException();
            //return Task.Run(() => SingleOrDefault());
        }

        public override Task<TModel> SingleOrDefaultAsync(Expression<Func<TModel, bool>> single)
        {
            throw new NotImplementedException();
            //return Task.Run(() => SingleOrDefault(single));
        }

        public override List<TModel> ToList()
        {
            return _currentQuery.ToList();
        }

        public override Task<List<TModel>> ToListAsync()
        {
            throw new NotImplementedException();
            //return Task.Run(() => _currentQuery.ToList());
        }

        private readonly IQueryable<TModel> _currentQuery;
    }
}