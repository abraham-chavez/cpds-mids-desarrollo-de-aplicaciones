using CodeFirst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Employee> employyes = dataAccess.GetEmployees();

            foreach (Employee item in employyes)
            {
                Console.WriteLine(item.EmployeeID);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadKey();

            stopwatch.Reset();
            stopwatch.Start();

            using (CodeFirst.DataContext.CPDSEntities context = new CodeFirst.DataContext.CPDSEntities())
            {
                foreach (CodeFirst.DataContext.Employee item in context.Employee)
                {
                    Console.WriteLine(item.EmployeeID);
                }

                var result = from emp in context.Employee select emp;

                foreach (var item in result)
                {
                    Console.WriteLine(item.EmployeeID);
                }

                var result2 = from emp in context.Employee
                              select new
                              {
                                  NumeroEmpleado = emp.EmployeeID,
                                  Departamento = emp.Department,
                                  emp.JobPhoneNumber,
                                  emp.JobMail
                              };

                foreach (var item in result2)
                {
                    Console.WriteLine(item.JobMail);
                }

                foreach (var item in context.Employee.Select((emp) => new { emp.JobMail }))
                {
                    Console.WriteLine(item.JobMail);
                }
            }
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}