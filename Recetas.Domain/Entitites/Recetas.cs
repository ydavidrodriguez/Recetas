namespace Recetas.Domain.Entitites
{
    public class Recetas
    {
        public Guid IdReceta { get; set; }
        public string Descripcion { get; set; }
        public Guid IdEstado { get; set; }
        public Guid IdPaciente { get; set; }

    }
}
