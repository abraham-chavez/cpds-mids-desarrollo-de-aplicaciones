using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Int32, Int32> func1 = x => x + 1;
            Console.WriteLine($"Func1: {func1.Invoke(200)}");

            Func<Int32, Int32> func2 = x => { return x + 1; };
            Console.WriteLine($"Func2: {func2.Invoke(200)}");

            Func<Int32, Int32> func3 = (Int32 x) => { return x + 1; };
            Console.WriteLine($"Func3: {func3.Invoke(200)}");

            Func<Int32, Int32> func4 = (Int32 x) => x + 1; ;
            Console.WriteLine($"Func4: {func4.Invoke(200)}");

            Action action = () => Console.WriteLine("Hola expresiones Lambda");
            action.Invoke();

            Console.ReadKey();
        }
    }
}