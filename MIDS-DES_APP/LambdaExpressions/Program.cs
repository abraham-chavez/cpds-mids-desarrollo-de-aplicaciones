using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Int32> numbers = new List<int>() { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

            Console.WriteLine("La lista de números es: ");
            foreach (Int32 number in numbers)
            {
                Console.WriteLine($"{number} ");
            }
            Console.WriteLine();

            var square = numbers.Select(x => x * x);
            Console.WriteLine("Números al cuadrado: ");
            foreach (Int32 number in square)
            {
                Console.WriteLine($"{number} ");
            }
            Console.WriteLine();

            var divBy3 = numbers.FindAll(x => (x % 3) == 0);
            Console.WriteLine("Números divisibles por 3: ");
            foreach (Int32 number in divBy3)
            {
                Console.WriteLine($"{number}");
            }
            Console.ReadKey();
        }
    }
}