using System;
using System.Collections.Generic;
using Arbol_1;
using System.Linq;

internal class GrafoGenealogico
{
    private Dictionary<Person, List<Person>> adyacencia;

    public GrafoGenealogico() 
    {
        adyacencia = new Dictionary<Person, List<Person>>();
    }
    public void AddPerson(Person p) //Anadir persona al grafo
    {
        if (p == null)
            return;
        if (!adyacencia.ContainsKey(p))
            adyacencia[p] = new List<Person>();
    }

    public void AddChildren(Person father, Person child) //Agrega un hijo a un padre, crea las dos personas si no existen
    {
        if (father == null || child == null)
            return;
        if (!adyacencia.ContainsKey(father))
            adyacencia[father] = new List<Person>();
        father.AddChild(child);
        adyacencia[father].Add(child);
    }
    public void AddFather(Person hijo, Person father) //Agrega un padre a una persona ya existente
    {
        if (hijo == null || father == null)
            return;
        if (hijo.CanAddParent())
        {
            hijo.AddParent(father);
            father.AddChild(hijo);
            adyacencia[father].Add(hijo);
        }
    }

    public void DeletePerson(Person p) //Elimina una persona del grafo y conexiones con otras instancias de personas
    {
        if (p == null)
            return;
        if (adyacencia.ContainsKey(p))
        {
            // Eliminar nodo principal del grafo
            adyacencia.Remove(p);

            // Recorrer copia de las claves para evitar error
            var claves = new List<Person>(adyacencia.Keys);

            foreach (var key in claves)
            {
                // Si p estaba como hijo de key
                if (adyacencia[key].Contains(p))
                {
                    adyacencia[key].Remove(p);
                    key.RemoveChild(p);
                }

                // Si p estaba como padre de key
                if (key.Parents.Contains(p))
                {
                    key.RemoveParent(p);
                }
            }
        }
    }
}
