using Microsoft.EntityFrameworkCore;
using Recetas.Domain.Services.Interfaces.IRepositories;

namespace Recetas.Infraestructure.Respositories
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly Database.DataBaseService _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(Database.DataBaseService context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
