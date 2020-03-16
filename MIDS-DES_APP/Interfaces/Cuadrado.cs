using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Cuadrado : Cuadrilatero, ICalculos
    {
        public Decimal Lado1 { get; set; }
        public Decimal Lado2 { get; set; }
        public Decimal Lado3 { get; set; }
        public Decimal Lado4 { get; set; }

        public void CalcularArea()
        {
            base.Area = this.Lado1 * this.Lado2;
        }

        public void CalcularPerimetro()
        {
            base.Perimetro = this.Lado1 * 4;
        }
    }
}
