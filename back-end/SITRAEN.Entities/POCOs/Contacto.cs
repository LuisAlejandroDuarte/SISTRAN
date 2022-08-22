

namespace SITRAEN.Entities.POCOs
{
    public class Contacto
    {
        public long Id { get; set; } 
        public long PersonaId { get; set; }
        public virtual Persona? Persona { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;

    }
}
