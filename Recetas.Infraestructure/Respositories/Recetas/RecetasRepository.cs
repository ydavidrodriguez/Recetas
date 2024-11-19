using Recetas.Domain.Services.Interfaces.Recetas;
using Recetas.Infraestructure.Database;

namespace Recetas.Infraestructure.Respositories.Recetas
{
    public class RecetasRepository : EntityRepository<Domain.Entitites.Recetas>, IRecertaRepository
    {

        private readonly DataBaseService _context;
        public RecetasRepository(DataBaseService context) : base(context)
        {
            this._context = context;
        }

    }
}
