using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloqueoDeRecursos
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMaker coffee = new CoffeeMaker(800);

            //Parallel.For(0, 1000, (index) =>
            //{
            //    Boolean result = coffee.MakeCofees(8);
            //    Console.WriteLine($"El índice {index} intentó realizar 8 cafés y el resultado fue: {result}");
            //});

            Parallel.For(0, 10000, (index) =>
            {
                coffee.MakeCoffeeRequest(index, 8);
            });

            Parallel.For(0, 10000, (index) =>
            {
                coffee.MakeCoffeeRequestConcurrent(index, 8);
            });

            //for (int i = 0; i < 10000; i++)
            //{
            //    coffee.MakeCoffeeRequest(i, 8);
            //}

            Console.WriteLine();
            Console.WriteLine($"Nivel disponible final: {coffee.Stock}");

            Console.ReadKey();
        }
    }

    public class CoffeeMaker
    {
        private Object coffeeLock;
        private Int32 stock;
        private ConcurrentDictionary<Int32, Int32> concurrentRequests;
        private Dictionary<Int32, Int32> requests;

        public int Stock { get => stock; }


        public CoffeeMaker(Int32 stock)
        {
            this.stock = stock;
            this.coffeeLock = new Object();
            this.concurrentRequests = new ConcurrentDictionary<int, int>();
            this.requests = new Dictionary<int, int>();
        }

        public Boolean MakeCofees(Int32 coffeesRequired)
        {
            lock (this.coffeeLock)
            {
                if (coffeesRequired <= stock)
                {
                    Console.WriteLine($"Nivel disponible antes del despacho: {this.stock}");

                    this.stock -= coffeesRequired;
                    Console.WriteLine($"Se despacharon {coffeesRequired} cafés");
                    Console.WriteLine($"Nivel disponible despues del despacho: {this.stock}");

                    return true;
                }
                else
                {
                    Console.WriteLine($"No es posible despachar {coffeesRequired} cafés. El nivel disponible es de: {this.stock}");
                    return false;
                }
            }
        }

        public void MakeCoffeeRequest(Int32 index, Int32 coffeesrequired)
        {
            lock (this.coffeeLock)
            {
                this.requests.Add(index, coffeesrequired);
            }
        }

        public void MakeCoffeeRequestConcurrent(Int32 index, Int32 coffeesrequired)
        {
            this.concurrentRequests.TryAdd(index, coffeesrequired);
        }
    }
}