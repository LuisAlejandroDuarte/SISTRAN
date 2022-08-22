
namespace SITRAEN.DTOs.Persona
{
    public class PersonaDTO: ColumnsAccion
    {
        public long Id { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }


        public List<ContactoDTO>? Contactos { get; set; }

    }
}
