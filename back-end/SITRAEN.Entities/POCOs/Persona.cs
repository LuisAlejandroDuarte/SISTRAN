
namespace SITRAEN.Entities.POCOs
{
    public class Persona
    {
        public long Id { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Contacto>? Contactos { get; set; }

    }
}
