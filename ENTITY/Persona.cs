using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITY
{
    public class Persona
    {
        public Persona(string identificacion, string nombre, int edad, string sexo, double altura, double peso)
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
        public double Altura { get; set; }
        public double Peso { get; set; }
        public decimal Imc { get; set; }
        public override string ToString()

        {
            return $"Identificacion: {Identificacion} - Nombre:{Nombre}-Edad:{Edad} -Sexo:{Sexo} -Altura: {Altura}-Peso: {Peso}-IMC: {Imc} ";
        }

        public void CalcularImc()
        {

            if (Sexo.ToUpper().Equals("F"))
            {
                Imc = Convert.ToDecimal( Peso + Peso );
            }
            else if (Sexo.ToUpper().Equals("M"))
            {
                Imc = Convert.ToDecimal(Peso / (Altura * Altura));
            }
            else
            {
                Imc = 0;
            }

        }
    }
}
