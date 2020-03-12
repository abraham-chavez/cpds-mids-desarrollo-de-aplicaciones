using Objetos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona("Pedro Pérez Penas", new DateTime(2000, 1, 1));

            Console.WriteLine($"Hola {persona.Nombre}. Bienvenido a desarrollo de aplicaciones");

            Stopwatch tiempo = new Stopwatch();

            tiempo.Start();
            for (int i = 0; i < 50000; i++)
            {
                persona.Pasatiempos += $"Pasatiempo {i} - ";
            }
            tiempo.Stop();

            Console.WriteLine($"Los pasatiempos de {persona.Nombre} son: {persona.Pasatiempos}");
            Console.WriteLine($"Tiempo total de ejecución: {tiempo.ElapsedMilliseconds}");

            Console.ReadKey();
        }
    }
}
