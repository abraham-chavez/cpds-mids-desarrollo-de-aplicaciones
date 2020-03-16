using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Rectangulo : Cuadrilatero, ICalculos
    {
        public Decimal Base { get; set; }
        public Decimal Altura { get; set; }

        public void CalcularArea()
        {
            base.Area = this.Base * this.Altura;
        }

        public void CalcularPerimetro()
        {
            base.Perimetro = (this.Base + this.Altura) * 2;
        }
    }
}
