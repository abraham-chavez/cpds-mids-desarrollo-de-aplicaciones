using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OperacionesAsincronas
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongRunning();
            var result = GetData().Result;
            Console.WriteLine(result);

            Console.WriteLine("Fin de la ejecución");
            Console.ReadKey();
        }

        private static async Task<String> GetData()
        {
            String result = await Task.Run<String>(()=>
            {
                Thread.Sleep(5000);
                return "Estos son los datos";
            });

            return result;
        }

        private static async void LongRunning()
        {
            Task<String> task = Task.Run<String>(() =>
            {
                Thread.Sleep(5000);
                return "La tarea asíncrona ha finalizado";
            });

            String result = await task;

            Console.WriteLine(result);
        }
    }
}