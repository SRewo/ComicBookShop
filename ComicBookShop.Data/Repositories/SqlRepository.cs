using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {

        private DbSet<T> _dbSet;

        public SqlRepository(DbContext dataContext)
        {

            _dbSet = dataContext.Set<T>();

        } 


        public void Delete(T entity)
        {

            _dbSet.Remove(entity);

        }

        public IQueryable<T> GetAll()
        {

            return _dbSet;

        }

        public T GetById(int id)
        {

            return _dbSet.Find(id);

        }


        public void AddOrUpdate(T entity)
        {

            _dbSet.AddOrUpdate(entity);

        }

    }
}
