using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeDatos_Constructores
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 entero = 0;
            Temp temp = new Temp(40);
            MiEnumerador miEnumerador = MiEnumerador.Lunes;

            Console.WriteLine($"El valor de la variable entero de la clase Temp es: {temp.Entero}");
            Console.WriteLine($"El valor de la variable entero es: {entero}");
            Console.WriteLine($"El valor de la variable miEnumerador es: {miEnumerador.ToString()}");
            Console.WriteLine("El valor de la variable miEnumerador es: " + miEnumerador.ToString());
            Console.WriteLine($"El valor de la variable miEnumerador es: {(Int32)miEnumerador}");

            Int64 sum1 = 3;
            Int64 sum2 = 4;

            Int64 result = Sum(sum1, sum2);

            Console.WriteLine($"El resultado de la suma de {sum1} + {sum2} es igual a: {result}");

            Boolean boolean = false;

            Console.WriteLine($"El valor de la variable boolean es: {boolean}");
            boolean = true;
            Console.WriteLine($"El valor de la variable boolean es {boolean}");

            Console.WriteLine($"El valor de la variable boolean de la clase Temp es: {temp.boolean}");

            Int32 valor = 5;
            Int32 valorResult = ModificarValueType(valor);
            Console.WriteLine($"La variable valor conitne: {valor} y la variable valorResult contiene: {valorResult}");

            Temp tempRF = new Temp(5);
            Temp tempResult = ModificarReferencetype(tempRF);
            Console.WriteLine($"El valor de la variable Entero de la clase tempRF contiene: {tempRF.Entero}");
            Console.WriteLine($"El valor de la variable Entero de la clase tempresult contiene: {tempResult.Entero}");

            Temp y = new Temp();
            Temp x = y;
            x.Entero = 5;
            y.boolean = true;

            Console.WriteLine($"El valor de la variable Entero de la clase x contiene: {x.Entero} - {x.boolean}");
            Console.WriteLine($"El valor de la variable Entero de la clase y contiene: {y.Entero} - {y.boolean}");

            y.Entero = 6;
            x.boolean = false;

            Console.WriteLine($"El valor de la variable Entero de la clase x contiene: {x.Entero} - {x.boolean}");
            Console.WriteLine($"El valor de la variable Entero de la clase y contiene: {y.Entero} - {y.boolean}");

            x = new Temp();
            x.boolean = true;
            x.Entero = 10;

            Console.WriteLine($"El valor de la variable Entero de la clase x contiene: {x.Entero} - {x.boolean}");
            Console.WriteLine($"El valor de la variable Entero de la clase y contiene: {y.Entero} - {y.boolean}");


            Console.ReadKey();
        }

        private static Temp ModificarReferencetype(Temp temp)
        {
            temp.Entero = temp.Entero + 1;
            return temp;
        }

        private static Int32 ModificarValueType(Int32 valor)
        {
            valor = valor + 1;
            return valor;
        }

        private static Int64 Sum(Int64 sum1, Int64 sum2)
        {
            return sum1 + sum2;
        }
    }

    public enum MiEnumerador
    {
        Lunes = 2,
        Martes = 3,
        Miercoles = 4,
        Jueves = 5,
        Viernes = 6,
        Sabado = 7,
        Domingo = 1
    }

    public class Temp
    {
        public Int32 Entero { get; set; }

        public Boolean boolean;

        public Temp()
        {

        }

        public Temp(Int32 entero)
        {
            this.Entero = entero;
        }
    }
}