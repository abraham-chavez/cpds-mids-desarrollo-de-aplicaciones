﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Employee : Person
    {
        #region Static fields
        private static String DOMAIN = "@myapp.com";
        #endregion

        #region Fields
        private String employeeNumber;
        private String department;
        private String jobPosition;
        private String jobEmail;
        private String jobPhoneNumber;
        private String password;
        #endregion

        #region Properties
        public String EmployeeNumber { get => employeeNumber; }
        public String JobEmail { get => jobEmail; }
        public String Department { get => department; set => department = value; }
        public String JobPosition { get => jobPosition; set => jobPosition = value; }
        public String JobPhoneNumber { get => jobPhoneNumber; set => jobPhoneNumber = value; }
        public String Password { get => password; set => password = value; }
        #endregion

        #region Constructors
        public Employee(String employeeNumber) : base()
        {
            this.employeeNumber = employeeNumber;
            this.GenerateJobEmail();
        }

        public Employee(String name, String secondName, String lastName, DateTime birthday, String rfc, String employeeNumber) :
            base(name, secondName, lastName, birthday, rfc)
        {
            this.employeeNumber = employeeNumber;
            this.GenerateJobEmail();
        }

        public Employee(String name, String secondName, String lastName, DateTime birthday, String rfc, String email, String phoneNumber, String employeeNumber) :
            base(name, secondName, lastName, birthday, rfc, email, phoneNumber)
        {
            this.employeeNumber = employeeNumber;
            this.GenerateJobEmail();
        }
        #endregion

        #region Methods
        private void GenerateJobEmail()
        {
            Regex reg = new Regex("[^a-zA-Z0-9]");

            String normalizedName = reg.Replace(base.Name.ToLower().Normalize(NormalizationForm.FormD), "");
            String normalizationLastName = reg.Replace(base.LastName.ToLower().Split(' ')[0].Normalize(NormalizationForm.FormD), "");

            this.jobEmail = $"{normalizedName}.{normalizationLastName}{DOMAIN}";
        }

        public sealed override string ToString()
        {
            String baseMessage = base.ToString();
            Console.WriteLine($"{baseMessage} Soy empleado con ID {this.employeeNumber} y mi correo electrónico del trabajo es: {this.jobEmail}");
            return $"{baseMessage} Soy empleado con ID {this.employeeNumber} y mi correo electrónico del trabajo es: {this.jobEmail}";
        }

        public sealed override string ToString(IFormatProvider formatProvider)
        {
            String baseMessage = base.ToString(formatProvider);

            return $"{baseMessage} Soy empleado con ID {this.employeeNumber} y mi correo electrónico del trabajo es: {this.jobEmail}";
        }

        public override string ExapleMethodAbstract()
        {
            Console.WriteLine("Este es un mensaje desde el método ExapleMethodAbstract de la clase Emplopyee ");
            return "Este es un mensaje desde el método ExapleMethodAbstract de la clase Emplopyee ";
        }

        public void ExapleMethodAction(String value)
        {
            Console.WriteLine($"Mi nombre es {this.Name} y el valor pasado como parámetro es: {value}");
        }
        #endregion
    }
}