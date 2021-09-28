using DLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;

        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guardar(Persona persona)
        {
            try
            {
                if (personaRepository.BuscarPorIdentificacion(persona.Identificacion) == null)
                {
                    personaRepository.Guardar(persona);
                    return "Datos Guardados Satisfactoriamente";
                }
                return $"La Persona con la Identificacion {persona.Identificacion} ya se encuentra registrada";

            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion) != null)
                {
                    personaRepository.Eliminar(identificacion);
                    return $"Se eliminó a la Persona con idnetificacion {identificacion}";
                }
                return $"No se encontró a la persona con Identificacion {identificacion}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }

        }

        public string Modificar(Persona personaNueva, string identificacion)
        {

            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion) != null)
                {
                    personaRepository.Modificar(personaNueva, identificacion);
                    return $"Se Modificó a la Persona con idnetificacion {identificacion}";
                }
                return $"No se encontró a la persona con Identificacion {identificacion}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }

        public PersonaResponse BuscarPorIdentificacion(string identificacion)
        {
            PersonaResponse personaResponse;
            try
            {
                Persona persona = personaRepository.Buscar(identificacion);
                if (persona != null)
                {
                    return personaResponse = new PersonaResponse(persona);
                }
                else
                {
                    return personaResponse = new PersonaResponse("La Persona buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return personaResponse = new PersonaResponse("Error de Aplicacion: " + e.Message);
            }

        }

        public ConsultaPersonaResponse ConsultarTodos()
        {

            ConsultaPersonaResponse personaResponse;
            try
            {
                List<Persona> personas = personaRepository.ConsultarTodos();
                if (personas != null)
                {
                    return personaResponse = new ConsultaPersonaResponse(personas);
                }
                else
                {
                    return personaResponse = new ConsultaPersonaResponse("La Persona buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return personaResponse = new ConsultaPersonaResponse("Error de Aplicacion: " + e.Message);
            }
        }

        public class PersonaResponse
        {
            public Persona Persona { get; set; }
            public string Message { get; set; }
            public bool PersonaEncontrada { get; set; }

            public PersonaResponse(Persona persona)
            {
                Persona = new Persona();
                Persona = persona;
                PersonaEncontrada = true;
            }
            public PersonaResponse(string message)
            {
                Message = message;
                PersonaEncontrada = false;
            }
        }

        public class ConsultaPersonaResponse
        {
            public List<Persona> Personas { get; set; }
            public string Message { get; set; }
            public bool PersonaEncontrada { get; set; }

            public ConsultaPersonaResponse(List<Persona> personas)
            {
                Personas = new List<Persona>();
                Personas = personas;
                PersonaEncontrada = true;
            }
            public ConsultaPersonaResponse(string message)
            {
                Message = message;
                PersonaEncontrada = false;
            }
        }

    }
   
}

