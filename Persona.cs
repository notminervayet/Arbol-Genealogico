using System;
using System.Collections.Generic;

namespace Arbol_1
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaFallecimiento { get; set; }
        public string FotoPath { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public List<Persona> Hijos { get; set; }
        public Persona Padre { get; private set; }
        public Persona Madre { get; private set; }

        public Persona(string nombre, string cedula, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Cedula = cedula;
            FechaNacimiento = fechaNacimiento;
            FechaFallecimiento = null;
            FotoPath = null;
            Latitud = 0;
            Longitud = 0;
            Hijos = new List<Persona>();
        }
        public void AgregarHijo(Persona hijo)
        {
            Hijos.Add(hijo);
        }

        public void SetPadre(Persona padre)
        {
            Padre = padre;
            padre.AgregarHijo(this);
        }

        public void SetMadre(Persona madre)
        {
            Madre = madre;
            madre.AgregarHijo(this);
        }
        public int CalcularEdad()
        {
            DateTime fechaFinal = FechaFallecimiento ?? DateTime.Now;
            int edad = fechaFinal.Year - FechaNacimiento.Year;
            if (fechaFinal < FechaNacimiento.AddYears(edad)) edad--;
            return edad;
        }
    }
}
