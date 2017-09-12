using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DDDExample.Domain.Interfaces.Repositories;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        #region Fields

        private readonly IRepositoryBase<TEntity> _repository;

        #endregion
        
        #region Constructors

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public void Add(TEntity objModel)
        {
            _repository.Add(objModel);
        }

        public void AddRange(IEnumerable<TEntity> objModel)
        {
            _repository.AddRange(objModel);
        }

        public TEntity GetId(int id)
        {
            return _repository.GetId(id);
        }

        public async Task<TEntity> GetIdAsync(int id)
        {
            return await _repository.GetIdAsync(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetList(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAllAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public int Count()
        {
            return _repository.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public void Update(TEntity objModel)
        {
            _repository.Update(objModel);
        }

        public void Remove(TEntity objModel)
        {
            _repository.Remove(objModel);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        #endregion
    }
}
