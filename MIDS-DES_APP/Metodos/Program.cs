using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean ejecutarDenuevo = false;
            do
            {
                Console.WriteLine("Bienvenido al módulo 1.3.4 - Métodos");
                Console.WriteLine("Este propgrama realiza operaciones aritméticas");
                Console.WriteLine("Seleccione una opción");
                Console.WriteLine("1 - Sumar dos números enteros");
                Console.WriteLine("2 - Sumar dos números decimales");
                Console.WriteLine("3 - Multiplicar dos números");
                Console.WriteLine("4 - Salir");
                Console.WriteLine("Por favor escriba una opción");
                String opcionResult = Console.ReadLine();

                String sum1 = String.Empty;
                String sum2 = String.Empty;
                Operaciones operaciones = new Operaciones();

                switch (opcionResult)
                {
                    case "1":
                        Console.WriteLine("Por favor ingrese el primer número entero");
                        sum1 = Console.ReadLine();

                        Console.WriteLine("Por favor ingrese el segundo número entero");
                        sum2 = Console.ReadLine();

                        Int32 sumando1;
                        Int32.TryParse(sum1, out sumando1);

                        Int32.TryParse(sum2, out Int32 sumando2);

                        //Console.WriteLine($"El resultado de sumar {sum1} + {sum2} es: {operaciones.Sumar(sumando1, sumando2)}");
                        Console.WriteLine($"El resultado de sumar {sum1} + {sum2} es: {operaciones.Sumar(sumando1, sumando2, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 21, 12, 12, 12, 12, 12, 12, 12, 12, 12)}");
                        break;
                    case "2":
                        break;
                    case "3":
                        Int32 mult1 = 2;
                        Int32 mult2 = 2;

                        operaciones.Multiplicar(mult1, mult2);
                        Console.WriteLine($"El resultado de multiplicar {mult1} * {mult2} es: {mult1}");

                        operaciones.Multiplicar(ref mult1, mult2);
                        Console.WriteLine($"El resultado de multiplicar {mult1} * {mult2} es: {mult1}");
                        break;
                    case "4":
                        //Opción 1
                        Console.WriteLine("Hasta luego.");
                        Console.ReadKey();
                        return;

                    //Opción 2
                    //Console.WriteLine("Hasta luego.");
                    //ejecutarDenuevo = false;
                    //goto Finalizar;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("¿Desea ejecutar de nuevo el programa S/N.?");
                String ejecResult = Console.ReadLine();

                if (ejecResult.ToLower() == "s")
                {
                    ejecutarDenuevo = true;
                }
                else
                {
                    Console.WriteLine("Hasta luego.");
                    ejecutarDenuevo = false;
                }
            Finalizar:

                Console.Clear();

            } while (ejecutarDenuevo);

            Console.ReadKey();
        }
    }

    public class Operaciones
    {
        public void Multiplicar(ref Int32 mult1, Int32 mult2)
        {
            mult1 *= mult2;
        }

        public void Multiplicar(Int32 mult1, Int32 mult2)
        {
            mult1 *= mult2;
        }

        public Int32 Sumar(Int32 sum1, Int32 sum2, Int32 sum3 = 0, Int32 sum4 = 0, Int32 sum5 = 0)
        {
            return sum1 + sum2 + sum3 + sum4 + sum5;
        }

        public Int32 Sumar(params Int32[] numero)
        {
            Int32 total = 0;

            for (int i = 0; i < numero.Length; i++)
            {
                total += numero[i];
            }

            return total;
        }

        public Decimal Sumar(Decimal sum1, Decimal sum2)
        {
            return sum1 + sum2;
        }

        public String RecuperarTexto(String nombreArchivo, out String directorio, out String tamanio, out String lineas)
        {
            directorio = String.Empty;
            tamanio = String.Empty;
            lineas = String.Empty;

            return String.Empty;
        }
    }
}