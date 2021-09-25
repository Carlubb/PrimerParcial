using System;

namespace Entidad
{
    public class Persona
    {
    
    public Persona(string identificacion, string nombre, int edad, string sexo, decimal altura, decimal peso)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            Altura = altura;
            Peso = peso;
        }
        
        public Persona()
        {

        }

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public decimal Imc { get; set; }
        public override string ToString()
            
            {
            return $"Identificacion: {Identificacion} - Nombre:{Nombre}-Edad:{Edad} -Sexo:{Sexo} -Altura: {Altura}-Peso: {Peso}-Pulsacion: {Imc} ";
            }
        
             public void CalcularPulsacion()
        {
       
            if (Sexo.ToUpper().Equals("F"))
            {
                Imc = Peso/(220 * Edad) - 1;
            }
            else if (Sexo.ToUpper().Equals("M"))
            {
                Imc = Peso / (220 * Edad) ;
            }
            else
            {
                Imc = 0;
            }

        }
    }
}
