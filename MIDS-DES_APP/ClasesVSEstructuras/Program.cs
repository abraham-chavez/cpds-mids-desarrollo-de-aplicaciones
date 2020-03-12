using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesVSEstructuras
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona("Pedro Pérez Penas", new DateTime(2000, 1, 1));

            PersonaST personast1 = new PersonaST();
            personast1.Nombre = "Juan Pérez Penas";
            personast1.FechaNacimiento = new DateTime(2002, 1, 1);
            personast1.Edad = 18;

            Console.WriteLine($"persona1 - {persona1.Nombre} nació el {persona1.FechaNacimiento} y tiene {persona1.Edad} años");
            Console.WriteLine($"personast1 - {personast1.Nombre} nació el {personast1.FechaNacimiento} y tiene {personast1.Edad} años");

            Persona persona2 = persona1;
            persona2.Edad = 30;

            PersonaST personast2 = personast1;
            personast2.Edad = 20;

            Console.WriteLine($"persona1 - {persona1.Nombre} nació el {persona1.FechaNacimiento} y tiene {persona1.Edad} años");
            Console.WriteLine($"persona2 - {persona2.Nombre} nació el {persona2.FechaNacimiento} y tiene {persona2.Edad} años");
            
            Console.WriteLine($"personast1 - {personast1.Nombre} nació el {personast1.FechaNacimiento} y tiene {personast1.Edad} años");
            Console.WriteLine($"personast2 - {personast2.Nombre} nació el {personast2.FechaNacimiento} y tiene {personast2.Edad} años");

            Console.ReadKey();
        }
    }

    public struct PersonaST
    {
        public String Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Byte Edad { get; set; }
    }
}