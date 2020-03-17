using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados
{
    class Program
    {
        public delegate String GetToString();

        static void Main(string[] args)
        {
            GetToString getToString;

            Employee gabriel = new Employee("Gabriel", "Alejandro", "Pérez Castillo", new DateTime(1988, 01, 30), "GAPC880130A1B", "gabriel@hotmail.com"
                , "5554387928", "123456")
            {
                Department = "Producción",
                JobPhoneNumber = "5557854321",
                JobPosition = "Supervisor",
            };

            Employee antonio = new Employee("José", "Antonio", "Contreras Hernández", new DateTime(1985, 07, 30), "JACH850730A1B", "antonio@hotmail.com"
                , "5554327928", "123457")
            {
                Department = "Producción",
                JobPhoneNumber = "5557854322",
                JobPosition = "Director",
            };

            Employee maria = new Employee("María", "del Carmen", "García Ortega", new DateTime(2000, 10, 15), "MCGO001015A1B", "maria@hotmail.com"
                , "5554327973", "123458")
            {
                Department = "Capital Humano",
                JobPhoneNumber = "5557854312",
                JobPosition = "Atracción de talento",
            };

            List<Employee> employees = new List<Employee>();
            employees.Add(gabriel);
            employees.Add(antonio);
            employees.Add(maria);

            getToString = gabriel.ToString;
            getToString += gabriel.ExapleMethodAbstract;
            getToString += antonio.ToString;
            getToString += antonio.ExapleMethodAbstract;
            getToString += maria.ToString;
            getToString += maria.ExapleMethodAbstract;

            getToString();
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Mensajes con FUNC");
            Func<String> toString = new Func<string>(gabriel.ToString);
            toString += gabriel.ExapleMethodAbstract;
            toString += antonio.ToString;
            toString += antonio.ExapleMethodAbstract;
            toString += maria.ToString;
            toString += maria.ExapleMethodAbstract;

            toString();
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Mensajes con Action");

            Action<String> action = new Action<string>(gabriel.ExapleMethodAction);
            action += antonio.ExapleMethodAction;
            action += maria.ExapleMethodAction;

            action("Así funciona Action");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            //Predicate<Employee> predicate = e => e.Department == "Producción" && e.JobPosition == "Director";
            Predicate<Employee> predicate = e => e.JobEmail.Contains("@myapp.com");

            foreach (Employee item in employees.FindAll(predicate))
            {
                Console.WriteLine($"{item.Name} {item.SecondName} {item.LastName}");
            }

            Console.ReadKey();
        }
    }
}