using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_1
{
    internal class Persona //Nodos del arbol (grafo) genealogico
    {
        string Nombre;
        string Cedula;
        DateTime FechaNacimiento;
        DateTime? FechaFallecimiento;
        string FotoPath;
        double Latitud, Longitud;
        List<Persona> Hijos;
        Persona Padre, Madre;
        void AgregarHijo(Persona hijo) //Anade un hijo a la lista de hijos
        {
            if (Hijos == null)
            {
                Hijos = new List<Persona>();
            }
            Hijos.Add(hijo);
        }
        void SetPadre(Persona padre) //Asigna el padre y anade este a la lista de hijos del padre
        {
            Padre = padre;
            padre.AgregarHijo(this);
        }

        void SetMadre(Persona madre) //Asigna la madre y anade esta a la lista de hijos de la madre
        {
            Madre = madre;
            madre.AgregarHijo(this);
        }

    }
}
