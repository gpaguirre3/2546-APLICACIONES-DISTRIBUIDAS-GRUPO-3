using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class EFRepository : IRepository
    {
        //el dbcontext que se utiliza para hacer la conexion con la base de datos
        DbContext _dbContext;
        //vamos hacer un constructor
        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            TEntity result = default;
            try
            {
                _dbContext.Set<TEntity>().Add(toCreate);
                _dbContext.SaveChanges();
                result = toCreate;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            bool result = false;
            try
            {
                //le pasamos a state deleted
                _dbContext.Entry<TEntity>(toDelete).State = EntityState.Deleted;
                //_dbContext.Entry(toDelete).State = EntityState.Deleted;

                result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> result = null;
            try
            {
                result = _dbContext.Set<TEntity>().Where(criteria).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        public TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity result = null;
            try
            {
                result = _dbContext.Set<TEntity>().FirstOrDefault(criteria);

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            bool result = false;
            try
            {
                //le pasamos a state deleted
                _dbContext.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                //_dbContext.Entry(toDelete).State = EntityState.Deleted;

                result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().ToList();
        }

    }
}
