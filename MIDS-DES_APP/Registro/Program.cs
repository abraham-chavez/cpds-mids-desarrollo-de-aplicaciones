using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Pedro", String.Empty, "Pérez Penas", new DateTime(2000, 01, 01), "AAAA000101ABC", "123456");
            Person employee1 = new Employee("Francisco", String.Empty, "Pérez Penas", new DateTime(2001, 01, 01), "AAAA010101ABC", "1234567");

            Provider provider1 = new Provider("Luis", String.Empty, "Pérez Penas", new DateTime(2001, 06, 20), "AAAA010101ABC", "1234568", "Empresa de cositas");
            Person provider2 = new Provider("Hugo", String.Empty, "Pérez Penas", new DateTime(2002, 06, 20), "AAAA010101ABC", "1234569", "Empresa de cositas");
            SubProvider subProvider = new SubProvider("Juan", String.Empty, "Pérez Penas", new DateTime(2002, 06, 20), "AAAA010101ABC", "1234569", "Empresa de cositas");

            Person[] persons = new Person[5];
            persons[0] = employee;
            persons[1] = employee1;
            persons[2] = provider1;
            persons[3] = provider2;
            persons[4] = subProvider;

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine(persons[i].ExapleMethodAbstract() + $" - Soy del tipo {persons[i].GetType().ToString()}");
            }

            Console.ReadKey();
        }
    }
}