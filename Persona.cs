using System;
using System.Collections.Generic;

namespace Arbol_1
{
    internal class Person
    {
        private string name { get; set; }
        private string id { get; set; }
        private DateTime birthdate { get; set; }
        private DateTime? deathDate { get; set; }
        private string fotoPath { get; set; }
        private List<Person> children { get; set; }
        private Person[] parents { get; set; }

        public Person(string name, string id, DateTime birthdate) //Metodo constructor con informacion basica
        {
            this.name = name;
            this.id = id;
            this.birthdate = birthdate;
            deathDate = null;
            fotoPath = null;
            children = new List<Person>();
            parents = new Person[2]; //Maximo dos padres
        }
        public void addChild(Person child) //Anade un hijo a la lista de hijos propia
        {
            if (child != null && !children.Contains(child))
            {
                children.Add(child);
            }
        }

        public bool canAddParent()
        {
            if (parents[0] == null || parents[1] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addParent(Person parent)
        {
            if (parent != null)
            {
                if (parents[0] == null)
                {
                    parents[0] = parent;
                }
                else if (parents[1] == null)
                {
                    parents[1] = parent;
                }
            }
        }
    }
}
