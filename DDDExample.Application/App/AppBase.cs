using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDExample.Application.Interfaces;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Application.App
{
    public class AppBase<TEntity> : IDisposable, IAppBase<TEntity> where TEntity : class
    {
        #region Fields

        private readonly IServiceBase<TEntity> _serviceBase;

        #endregion

        #region Constructors

        public AppBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        #endregion

        #region Methods

        public void Add(TEntity objModel)
        {
            _serviceBase.Add(objModel);
        }

        public void AddRange(IEnumerable<TEntity> objModel)
        {
            _serviceBase.AddRange(objModel);
        }

        public TEntity GetId(int id)
        {
            return _serviceBase.GetId(id);
        }

        public async Task<TEntity> GetIdAsync(int id)
        {
            return await _serviceBase.GetIdAsync(id);
        }

        //public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _serviceBase.Get(predicate);
        //}

        //public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _serviceBase.GetAsync(predicate);
        //}

        //public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _serviceBase.GetList(predicate);
        //}

        //public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _serviceBase.GetAllAsync();
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public int Count()
        {
            return _serviceBase.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _serviceBase.CountAsync();
        }

        public void Update(TEntity objModel)
        {
            _serviceBase.Update(objModel);
        }

        public void Remove(TEntity objModel)
        {
            _serviceBase.Remove(objModel);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        #endregion
    }
}
