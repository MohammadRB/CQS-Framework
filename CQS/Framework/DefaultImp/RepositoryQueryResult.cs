// [07/22/2016 MRB]

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Query;
using CQS.Framework.Repository;

namespace CQS.Framework.DefaultImp
{
    public class RepositoryQueryResult<TEntity, TModel> : QueryResult<TEntity, TModel>
         where TEntity : class
         where TModel : class
    {
        public RepositoryQueryResult(IReadRepository<TEntity> readRepository, Func<TEntity, TModel> mappingFunc)
        {
            _readRepository = readRepository;
            _mappingFunc = mappingFunc;

            _currentQuery = _readRepository.All();
        }

        public override IQueryResult<TEntity, TModel> Where(Expression<Func<TEntity, bool>> where)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.Where(where)
            };

            return newQueryBuilder;
        }

        public override IQueryResult<TEntity, TModel> Include<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.Include(include)
            };

            return newQueryBuilder;
        }

        public override IQueryResult<TEntity, TModel> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderby)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.OrderBy(orderby)
            };

            return newQueryBuilder;
        }

        public override IQueryResult< TEntity, TModel > OrderByDesc< TKey >(Expression< Func< TEntity, TKey > > @orderby)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.OrderByDescending(orderby)
            };

            return newQueryBuilder;
        }

        public override IQueryResult<TEntity, TModel> Skip(int skip)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.Skip(skip)
            };

            return newQueryBuilder;
        }

        public override IQueryResult<TEntity, TModel> Take(int take)
        {
            var newQueryBuilder = new RepositoryQueryResult<TEntity, TModel>(_readRepository, _mappingFunc)
            {
                _currentQuery = _currentQuery.Take(take)
            };

            return newQueryBuilder;
        }

        public override TModel First()
        {
            var model = _mappingFunc(_currentQuery.First());

            return model;
        }

        public override TModel First(Expression<Func<TEntity, bool>> first)
        {
            var model = _mappingFunc(_currentQuery.First(first));

            return model;
        }

        public override Task<TModel> FirstAsync()
        {
            return Task.Run(() => First());
        }

        public override Task<TModel> FirstAsync(Expression<Func<TEntity, bool>> first)
        {
            return Task.Run(() => First(first));
        }

        public override TModel FirstOrDefault()
        {
            var entity = _currentQuery.FirstOrDefault();
            var model = entity != null ? _mappingFunc(entity) : null;

            return model;
        }

        public override TModel FirstOrDefault(Expression<Func<TEntity, bool>> first)
        {
            var entity = _currentQuery.FirstOrDefault(first);
            var model = entity != null ? _mappingFunc(entity) : null;

            return model;
        }

        public override Task<TModel> FirstOrDefaultAsync()
        {
            return Task.Run(() => FirstOrDefault());
        }

        public override Task<TModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> first)
        {
            return Task.Run(() => FirstOrDefault(first));
        }

        public override TModel Single()
        {
            var model = _mappingFunc(_currentQuery.Single());

            return model;
        }

        public override TModel Single(Expression<Func<TEntity, bool>> single)
        {
            var model = _mappingFunc(_currentQuery.Single(single));

            return model;
        }

        public override Task<TModel> SingleAsync()
        {
            return Task.Run(() => Single());
        }

        public override Task<TModel> SingleAsync(Expression<Func<TEntity, bool>> single)
        {
            return Task.Run(() => Single(single));
        }

        public override TModel SingleOrDefault()
        {
            var entity = _currentQuery.FirstOrDefault();
            var model = entity != null ? _mappingFunc(entity) : null;

            return model;
        }

        public override TModel SingleOrDefault(Expression<Func<TEntity, bool>> single)
        {
            var entity = _currentQuery.FirstOrDefault(single);
            var model = entity != null ? _mappingFunc(entity) : null;

            return model;
        }

        public override Task<TModel> SingleOrDefaultAsync()
        {
            return Task.Run(() => SingleOrDefault());
        }

        public override Task<TModel> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> single)
        {
            return Task.Run(() => SingleOrDefault(single));
        }

        public override List<TModel> ToList()
        {
            return _currentQuery.Select(_mappingFunc).ToList();
        }

        public override Task<List<TModel>> ToListAsync()
        {
            return Task.Run(() => _currentQuery.Select(_mappingFunc).ToList());
        }

        private readonly IReadRepository<TEntity> _readRepository;
        private readonly Func<TEntity, TModel> _mappingFunc;

        private IQueryable<TEntity> _currentQuery;
    }
}
