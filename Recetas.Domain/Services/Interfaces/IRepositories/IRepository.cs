namespace Recetas.Domain.Services.Interfaces.IRepositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        public void Save();

    }
}
