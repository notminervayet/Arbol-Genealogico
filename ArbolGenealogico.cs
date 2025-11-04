using System;
using System.Collections.Generic;
using Arbol_1;

internal class GrafoGenealogico
{
    private Dictionary<Person, List<Person>> adyacencia;

    public GrafoGenealogico() 
    {
        adyacencia = new Dictionary<Person, List<Person>>();
    }
    public void addPerson(Person p) //Anadir persona al grafo
    {
        if (!adyacencia.ContainsKey(p))
            adyacencia[p] = new List<Person>();
    }

    public void addChildren(Person father, Person child) //Arega un hijo a una persona ya existente
    {
        father.addChild(child);
        adyacencia[father].Add(father);
    }
    public void addFather(Person hijo, Person father) //Agrega un padre a una persona ya existente
    {
        if (hijo.canAddParent())
        {
            hijo.addParent(father);
            father.addChild(hijo);
            adyacencia[father].Add(hijo);
        }
    }

    public void deletePerson(Person p) //Eliminar persona del grafo
    {
        if (adyacencia.ContainsKey(p))
        {
            adyacencia.Remove(p);
            foreach (var key in adyacencia.Keys)
            {
                adyacencia[key].Remove(p);
            }
        }
    }
}
