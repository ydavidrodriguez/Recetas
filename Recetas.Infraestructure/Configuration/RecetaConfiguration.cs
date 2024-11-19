using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recetas.Infraestructure.Configuration
{
    public class RecetaConfiguration
    {
        public RecetaConfiguration(EntityTypeBuilder<Domain.Entitites.Recetas> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdReceta);
        }

    }
}
