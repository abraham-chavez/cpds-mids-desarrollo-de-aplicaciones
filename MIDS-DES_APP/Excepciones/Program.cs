using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            String guidEjecución = Guid.NewGuid().ToString();
            Console.WriteLine($"El identificador de esta sesión es: {guidEjecución}");

            Boolean ejecutarDenuevo = false;
            do
            {
                Console.WriteLine("Bienvenido al módulo 1.3.4 - Métodos");
                Console.WriteLine("Este propgrama realiza operaciones aritméticas");
                Console.WriteLine("Seleccione una opción");
                Console.WriteLine("1 - Sumar dos números enteros");
                Console.WriteLine("2 - Sumar dos números decimales");
                Console.WriteLine("3 - Multiplicar dos números");
                Console.WriteLine("4 - Dividir dos números");
                Console.WriteLine("5 - Salir");
                Console.WriteLine("Por favor escriba una opción");
                String opcionResult = Console.ReadLine();
                //Registro: El usuario capturó en el menú {opcionResult} con el id {guidEjecución}

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
                        Int32 mult1 = -1;
                        Int32 mult2 = -2;

                        try
                        {
                            operaciones.Multiplicar(mult1, mult2);
                            Console.WriteLine($"El resultado de multiplicar {mult1} * {mult2} es: {mult1}");

                            operaciones.Multiplicar(ref mult1, mult2);
                            Console.WriteLine($"El resultado de multiplicar {mult1} * {mult2} es: {mult1}");
                        }
                        catch (MultiplicacionPorNegativoException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        catch (ArithmeticException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;
                    case "4":

                        try
                        {
                            Single divResult = operaciones.Dividir(4, 0);
                            Console.WriteLine($"El resultado de vidivir 4/2 es: {divResult}");
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Ocurrió un error al momento de escribir o leer los datos. Por favor reporte con el administrador. ID de ejecución {guidEjecución}");
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine($"Ocurrió un error al intentar usar un objeto que es nulo. Por favor reportelo al administrador. ID de ejecución {guidEjecución}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"Ocurrió un error al intentar hacer una división por 0. ID ejecución {guidEjecución}");
                        }
                        catch (ArithmeticException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + $" ID de ejecución {guidEjecución}");
                        }
                        finally
                        {
                            Console.WriteLine("El bloque try catch ha finalizado");
                        }
                        break;
                    case "5":
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
        private static String ARITHMETIC_ERROR = "Ocurrió un error al realizar una operación en el módulo de operaciones.";
        private static String DIVIDE_ZERO_ERROR = "No es posible realizar una división por cero. Por favor elija otro número";

        public Single Dividir(Single dividendo, Single divisor)
        {
            //throw new ExecutionEngineException();

            if (divisor == 0)
            {
                throw new ArithmeticException(ARITHMETIC_ERROR, new DivideByZeroException(DIVIDE_ZERO_ERROR));
                //throw new DivideByZeroException(DIVIDE_ZERO_ERROR);
            }
            return dividendo / divisor;
        }

        public void Multiplicar(ref Int32 mult1, Int32 mult2)
        {
            mult1 *= mult2;
        }

        public void Multiplicar(Int32 mult1, Int32 mult2)
        {
            if (mult1 < 0 || mult2 < 0)
            {
                throw new MultiplicacionPorNegativoException($"Por regla de negocio no es posible multiplicar por un número negativo. {mult1} * {mult2}.", String.Empty);
            }
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

    public class MultiplicacionPorNegativoException : ArithmeticException
    {
        public String ExecutionGuid { get; set; }

        public MultiplicacionPorNegativoException() : base()
        {

        }

        public MultiplicacionPorNegativoException(String executionGuid)
        {
            this.ExecutionGuid = executionGuid;
        }

        public MultiplicacionPorNegativoException(String message, String executionGuid) : base(message)
        {

        }

        public MultiplicacionPorNegativoException(String message, Exception innerException, String executionGuid) : base(message, innerException)
        {

        }

        public MultiplicacionPorNegativoException(SerializationInfo info, StreamingContext context, String executionGuid) : base(info, context)
        {

        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.ExecutionGuid) == true && String.IsNullOrEmpty(base.Message) == false)
            {
                return base.Message;
            }

            if (String.IsNullOrEmpty(base.Message) == true && String.IsNullOrEmpty(this.ExecutionGuid) == false)
            {
                return $"Ocurrió un error al intentar multiplicar por un número negativo. ID de ejecución: {this.ExecutionGuid}";
            }

            return $"{base.Message} ID de ejecución: {this.ExecutionGuid}";
        }
    }
}