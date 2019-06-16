using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Entities
{
    public class RepositoryPattern<T> where T:class
    {
        DataContext db = new DataContext();
        public void Delete(T obj)
        {
            db.Set<T>().Remove(obj);
            Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        public int Insert(T obj)
        {
            db.Set<T>().Add(obj);
            return Save();
        }

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where(where).ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Count()
        {
            return db.Set<T>().Count();
        }
    }
}
