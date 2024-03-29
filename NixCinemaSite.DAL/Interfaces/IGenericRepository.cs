﻿using System.Linq.Expressions;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public ICollection<TEntity> Get
            (
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = ""
            );
        public TEntity GetByID(Guid id);
        public void Insert(TEntity entity);
        public void Delete(Guid id);
        public void Delete(TEntity entityToDelete);
        public void Update(TEntity entityToUpdate);
        public int Count();
        public void Save();
    }
}
