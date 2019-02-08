

using System.Linq;

namespace ComicBookShop.Data
{
    public interface IRepository<T>
    {
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}