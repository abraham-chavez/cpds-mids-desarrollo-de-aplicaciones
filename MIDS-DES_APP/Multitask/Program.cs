using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multitask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(GetThetime));
            Task task2 = new Task(delegate
            {
                Console.WriteLine($"La fecha actual es: {DateTime.Now.ToString("D")} - 2");
            });
            Task task3 = new Task(() =>
            {
                Console.WriteLine($"La fecha actual es: {DateTime.Now.ToString("D")} - 3");
            });

            task1.Start();
            task2.Start();
            task3.Start();

            var task4 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"La fecha actual es: {DateTime.Now.ToString("D")} - 4");
            });

            var task5 = Task.Run(() =>
            {
                Console.WriteLine($"La fecha actual es: {DateTime.Now.ToString("D")} - 5");
            });

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Task longRunning = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{i}");
                    Thread.Sleep(10);
                }
            });

            longRunning.Start();
            longRunning.Wait();

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Task[] tasks = new Task[3]
            {
                Task.Run(()=>LongRunning(100)),
                Task.Run(()=>LongRunning(110)),
                Task.Run(()=>LongRunning(120))
            };

            //Task.WaitAny(tasks);
            Task.WaitAll(tasks);

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Task<String> taskWithResult = Task.Run(() =>
            {
                return "Ejecución de tarea con resultado";
            });

            Console.WriteLine(taskWithResult.Result);

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            Task.Run(() => LongRunning(100, ct));

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Parallel.Invoke(() => LongRunning(50),
                () => LongRunning(100),
                () => LongRunning(150),
                () => LongRunning(200));

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Parallel.For(0, 100, index =>
             {
                 Console.WriteLine($"Estoy dentro del Parallel.For y el índice es: {index}");
             });

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            List<Int32> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            Parallel.ForEach(values, item =>
            {
                Console.WriteLine($"Estor dentro del Parallel.ForEach y el elemento es: {item}");
            });

            Console.WriteLine("Finalizó la ejecución");
            Console.ReadKey();
        }

        private static void LongRunning()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i}");
                Thread.Sleep(10);
            }
        }

        private static void LongRunning(Int32 length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i}");
                Thread.Sleep(10);
            }
        }

        private static void LongRunning(Int32 length, CancellationToken ct)
        {
            for (int i = 0; i < length; i++)
            {
                if (ct.IsCancellationRequested == true)
                {
                    Console.WriteLine("El usuario solicitó la cancelación de la tarea");
                    return;
                }
                Console.WriteLine($"{i}");
                Thread.Sleep(10);
            }
        }

        private static void GetThetime()
        {
            Console.WriteLine($"La fecha actual es: {DateTime.Now.ToString("D")}");
        }
    }
}
