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
                try
                {
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

                    string estado = (persona.Imc < 18) ? "Peso inferior a lo normal" :
                                    (persona.Imc < 25) ? "Peso normal" :
                                    (persona.Imc < 30) ? "Obesidad" : "Sobrepeso";

                    Console.WriteLine(estado);
                    Console.WriteLine($"Su indice de masa corporal es : {persona.Imc} " + message);

                }
                catch (Exception)
                {

                    throw;
                }
                
            }


            static void Editar()
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
                string message = personaService.Modificar(persona,identificacion);
                string estado = (persona.Imc < 18) ? "Peso inferior a lo normal" :
                                (persona.Imc < 25) ? "Peso normal" :
                                (persona.Imc < 30) ? "Obesidad" : "Sobrepeso";

                Console.WriteLine(estado);
                Console.WriteLine($"Su indice de masa corporal es : {persona.Imc} " + message);

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
                {
                    Console.WriteLine(personaResponse.Persona.ToString());
                    Editar();
                }
                    

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

            char Opcion;
            string Continuar;

            do
            {
                Console.WriteLine("Seleccionar una opcion  \n" +
            "\n1. CALCULAR INDICE DE MASA CORPORAL" +
            "\n2. MOSTRAS HISTORIAL DE PERSONAS" +
            "\n3. ELIMINAR PERSONA" +
            "\n4. MODIFICAR" +
            "\n5. SALIR \n");
                do
                {
                    Opcion = Console.ReadKey(true).KeyChar;

                } while (Opcion < '0' || Opcion > '5');

                switch (Opcion)
                {
                    case '1':
                        Calcular();
                        break;
                    case '2':
                        PersonaService personaService = new PersonaService();
                        Consultar(personaService);
                        break;
                    case '3':
                        Eliminar();
                        break;
                    case '4':
                        Buscar_Por_Identificacion();
                        break;
                    case '5':
                        
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        break;

                }

                Console.WriteLine("Desea continuar?(s/n)");
                Continuar = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();



            }

            while (Continuar != "n");

 

        }

    }
}
