using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class Empleado : Persona
    {
        public Empleado(String nombre, DateTime fechaNacimiento) : base(nombre, fechaNacimiento)
        {
        }
    }
}