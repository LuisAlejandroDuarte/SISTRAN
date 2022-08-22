
using AutoMapper;
using SITRAEN.DTOs;
using SITRAEN.DTOs.Persona;
using SITRAEN.Entities.Interfaces;
using SITRAEN.Entities.POCOs;
using SITRAEN.RepositoryEF.DataContext;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SITRAEN.RepositoryEF.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {

        readonly SitraenContext context;
        readonly IMapper imapper;

        public PersonaRepository(SitraenContext context, IMapper imapper)
        {
            this.context = context;
            this.imapper = imapper;
        }

        public PersonaDTO Crear(PersonaDTO persona)
        {
            Persona personaPOCO = new Persona();
            var find = context.Personas.Where(x => x.Documento == persona.Documento).FirstOrDefault();
            if (find!=null)
            {
                throw new Exception($"Ya existe otra persona con el mismo documento {persona.Documento} ");                        
            }

            personaPOCO.Documento = persona.Documento;
            personaPOCO.Apellidos = persona.Apellidos;

            personaPOCO.Nombres = persona.Nombres;
            personaPOCO.FechaNacimiento = persona.FechaNacimiento;
            personaPOCO.Contactos = new List<Contacto>();

            foreach (var item in persona.Contactos)
            {
                personaPOCO.Contactos.Add(new Contacto()
                {
                    Direccion=item.Direccion,
                    Telefono=item.Telefono,
                    Email=item.Email
                });
            }                       

            context.Add(personaPOCO);

            return persona;
        }


        public ContactoDTO EliminarContacto(long id)
        {
            var contacto = this.context.Contactos.Where(x => x.Id == id).FirstOrDefault();

            var contactoDTO = this.imapper.Map<ContactoDTO>(contacto);

            this.context.Remove(contacto);

            return contactoDTO;
        }

        public PersonaDTO Get(long Id)
        {
            PersonaDTO personaDTO = new PersonaDTO();
            var persona = context.Personas?.FirstOrDefault(x => x.Id == Id);
            if (persona == null)
            {
                throw new Exception($"La persona   con Id {Id} no existe");
            }

            var contactos = context.Contactos?.Where(x => x.PersonaId == persona.Id).ToList();

            persona.Contactos = contactos;

            personaDTO.Id = persona.Id;
            personaDTO.Documento = persona.Documento;
            personaDTO.Nombres = persona.Nombres;
            personaDTO.Apellidos = persona.Apellidos;
            personaDTO.FechaNacimiento = persona.FechaNacimiento;
            personaDTO.Contactos = new List<ContactoDTO>();

            foreach (var item in persona.Contactos)
            {
                personaDTO.Contactos.Add(new ContactoDTO()
                {
                    Id = item.Id,
                    Direccion = item.Direccion,
                    Telefono = item.Telefono,
                    Email = item.Email
                });
            }


            return personaDTO;
        }        




        public IEnumerable<PersonaDTO> GetAll()
        {
            return this.imapper.Map<List<PersonaDTO>>(this.context.Personas.ToList());
        }
    }
}
