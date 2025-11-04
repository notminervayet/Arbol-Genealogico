using System;
using System.Collections.Generic;
using Arbol_1;

internal class GrafoGenealogico
{
    private Dictionary<Persona, List<Persona>> adyacencia;

    public GrafoGenealogico() 
    {
        adyacencia = new Dictionary<Persona, List<Persona>>();
    }

    public void AgregarPersona(Persona p) //Anadir persona al grafo
    {
        if (!adyacencia.ContainsKey(p))
            adyacencia[p] = new List<Persona>();
    }

    public void Conectar(Persona padreOMadre, Persona hijo) //Conectar personas en el grafo
    {
        AgregarPersona(padreOMadre);
        AgregarPersona(hijo);
        adyacencia[padreOMadre].Add(hijo);
    }

    public List<Persona> ObtenerHijos(Persona p) //Obtener la lista de hijos de una persona
    {
        return adyacencia.ContainsKey(p) ? adyacencia[p] : new List<Persona>();
    }

    public void MostrarDescendencia(Persona p, int nivel = 0) //Mostrar en consola la descendencia de una persona
    {
        Console.WriteLine($"{new string(' ', nivel * 2)}- {p.Nombre}");
        if (adyacencia.ContainsKey(p))
        {
            foreach (var hijo in adyacencia[p])
                MostrarDescendencia(hijo, nivel + 1);
        }
    }
}
