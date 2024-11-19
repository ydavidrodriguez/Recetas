using Microsoft.EntityFrameworkCore;
using Recetas.Application;
using Recetas.Infraestructure.Configuration;

namespace Recetas.Infraestructure.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {


        }

        public DbSet<Domain.Entitites.Recetas> Recetas { get; set; }
       
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            new RecetaConfiguration(modelBuilder.Entity<Domain.Entitites.Recetas>());
        }

    }
}
