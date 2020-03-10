using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._2_Demo_VS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esta es mi primera línea en Github");

            Utils.Utilities utilities = new Utils.Utilities();

            Console.WriteLine($"La suma de los números 3 y 4 es {utilities.Sum(3, 4)}");
            Console.WriteLine("La URL de GitHub es http://github.com");
            Console.ReadKey();
        }
    }
}