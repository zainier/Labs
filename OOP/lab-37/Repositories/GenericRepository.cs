using System.Collections.Generic;
using System.Linq;
using Models;

namespace Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : Model
    {
        private static readonly List<T> Storage = new List<T>();

        public void Add(T entity)
        {
            Storage.Add(entity);
        }

        public T? GetById(int id)
        {
            return Storage.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return Storage.ToList();
        }

        public void Update(T entity)
        {
            int index = Storage.FindIndex(e => e.Id == entity.Id);

            if (index >= 0)
            {
                Storage[index] = entity;
            }
        }

        public void Delete(int id)
        {
            T? existing = Storage.FirstOrDefault(e => e.Id == id);

            if (existing is not null)
            {
                Storage.Remove(existing);
            }
        }
    }
}
