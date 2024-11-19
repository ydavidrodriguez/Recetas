using Microsoft.EntityFrameworkCore;

namespace Recetas.Application
{
    public interface IDataBaseService
    {
        public DbSet<Domain.Entitites.Recetas> Recetas { get; set; }

        Task<bool> SaveAsync();
    }
}
