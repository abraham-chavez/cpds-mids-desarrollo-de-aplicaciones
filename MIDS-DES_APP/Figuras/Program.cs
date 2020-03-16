using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculos cuadrado = new Cuadrado()
            {
                Lado1 = 4,
                Lado2 = 4,
                Lado3 = 4,
                Lado4 = 4
            };

            ICalculos rectangulo = new Rectangulo()
            {
                Base = 8,
                Altura = 4
            };

            ICalculos[] calculos = new ICalculos[2];
            calculos[0] = cuadrado;
            calculos[1] = rectangulo;

            for (int i = 0; i < calculos.Length; i++)
            {
                calculos[i].CalcularArea();
                calculos[i].CalcularPerimetro();
                Console.WriteLine($"El perímetro de la figura es: {(calculos[i] as Cuadrilatero).Perimetro} - El área de la figura es: {(calculos[i] as Cuadrilatero).Area}");
            }

            Console.ReadKey();

        }
    }
}