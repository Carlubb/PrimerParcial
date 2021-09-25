using DOMINIO;
using ENTITY;
using System;
using static DOMINIO.PersonaService;

namespace Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {

            static void Calcular()
            {
                string identificacion;
                string nombre;
                int edad;
                string sexo;
                double altura;
                double peso;

                Console.WriteLine("Digite la identificacion");
                identificacion = Console.ReadLine();

                Console.WriteLine("Digite el nombre");
                nombre = Console.ReadLine();

                Console.WriteLine("Digite el sexo");
                sexo = Console.ReadLine();

                Console.WriteLine("Digite la edad");
                edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite la altura en metros");
                altura = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite el peso en kilos");
                peso = double.Parse(Console.ReadLine());

                Persona persona = new Persona(identificacion, nombre, edad, sexo, altura, peso);
                PersonaService personaService = new PersonaService();
                persona.CalcularImc();
                string message = personaService.Guardar(persona);
                

                if(persona.Imc > 20)
                {
                    Console.WriteLine("USTED TIENE SOBREPESO \n");
                    Console.WriteLine($"SU INDICE DE MASA CORPORAL ES:  {persona.Imc} " + message);
                }
            }

            static void Consultar(PersonaService personaService)
            {
                ConsultaPersonaResponse consultaPersonaResponse = personaService.ConsultarTodos();
                if (consultaPersonaResponse.PersonaEncontrada == true)
                {
                    Console.WriteLine("Lista de Personas");
                    foreach (var item in consultaPersonaResponse.Personas)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine(consultaPersonaResponse.Message);
                }
            }

            static void Buscar_Por_Identificacion()
            {
                string identificacion;
                PersonaService personaService = new PersonaService();
                Console.WriteLine("Digite la identificacion");
                identificacion = Console.ReadLine();

                PersonaResponse personaResponse = personaService.BuscarPorIdentificacion(identificacion);
                if (personaResponse.PersonaEncontrada == true)
                    Console.WriteLine(personaResponse.Persona.ToString());
                else
                {
                    Console.WriteLine(personaResponse.Message);
                }
            }

            static void Eliminar()
            {
                string identificacion;
                PersonaService personaService = new PersonaService();
                Console.WriteLine("Digite la identificacion");
                identificacion = Console.ReadLine();
                string messageEliminacion = personaService.Eliminar(identificacion);
                Console.WriteLine(messageEliminacion);
            }

            Console.WriteLine("Seleccionar una opcion  \n"+
            "\n1. CALCULAR INDICE DE MASA CORPORAL" +
            "\n2. MOSTRAS HISTORIAL DE PERSONAS" +
            "\n3. ELIMINAR PERSONA" +
            "\n4. BUSCAR POR IDENTIFICACION" +
            "\n5. SALIR \n");

            String S1 = null;
            S1 = Console.ReadLine();

            switch (S1)
            {
                case "1":
                    Calcular();
                    break;
                case "2":
                    PersonaService personaService = new PersonaService();
                    Consultar(personaService);
                    break;
                case "3":
                    Eliminar();
                    break;
                case "4":
                    Buscar_Por_Identificacion();
                    break;
                case "5":
                    Console.WriteLine("Opcion");
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;

            }

            Console.ReadKey();


        }

         


    }
}
