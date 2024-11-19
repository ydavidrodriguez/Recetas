namespace Recetas.Domain.Dto
{
    public class CreateRecetasRequest
    {
        public Guid IdPaciente { get; set; }
        public Guid IdEstado { get; set; }
        public string Descripcion { get; set; }

    }
}
