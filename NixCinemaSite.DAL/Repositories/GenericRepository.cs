using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Interfaces;
using System.Linq.Expressions;

namespace NixCinemaSite.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        CinemaDbContext Context;

        DbSet<TEntity> DbSet;
        public GenericRepository(CinemaDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public ICollection<TEntity> Get
            (
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
                //фильтр по названию Например:
                //Get(c => c.Name == "Java")
                //Выведет один/несколько объектов с именем "Java"
                query = query.Where(filter);

            //вытягивание связных данных с бд
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            try
            {
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity GetByID(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(Guid id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public int Count()
        {
            return DbSet.Count();
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
