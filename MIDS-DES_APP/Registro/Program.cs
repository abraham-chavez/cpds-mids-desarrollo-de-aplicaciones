using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Pedro", String.Empty, "Pérez Penas", new DateTime(2000, 01, 01), "AAAA000101ABC", "123456");
            Console.WriteLine(employee.ToString());

            Console.ReadKey();
        }
    }
}