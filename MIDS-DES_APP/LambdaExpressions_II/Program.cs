using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions_II
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ RollID = 1, Name="Liza" },
                new Student(){ RollID = 2, Name="Stewart" },
                new Student(){ RollID = 3, Name="Pedro" },
                new Student(){ RollID = 4, Name="Tina" },
                new Student(){ RollID = 5, Name="Stefani" },
            };

            //var orderedStudents = students.OrderBy(x => x.Name);

            //foreach (var student in orderedStudents)
            //{
            //    Console.WriteLine($"{student.RollID} - {student.Name}");
            //}

            foreach (var student in students.OrderByDescending(x => x.Name))
            {
                Console.WriteLine($"{student.RollID} - {student.Name}");
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public Int32 RollID { get; set; }
        public String Name { get; set; }
    }
}