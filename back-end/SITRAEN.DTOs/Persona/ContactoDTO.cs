
using System.Diagnostics.Contracts;

namespace SITRAEN.DTOs.Persona
{
    public class ContactoDTO
    {
        public long Id { get; set; }
        public long PersonaId { get; set; }        
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
    }
}
