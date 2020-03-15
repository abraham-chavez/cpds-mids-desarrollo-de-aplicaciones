using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Person
    {
        #region Fields
        private String name;
        private String secondName;
        private String lastName;
        private DateTime birthday;
        private String rfc;
        private String messageToString;
        #endregion

        #region Properties
        public string Name { get => name; }
        public string SecondName { get => secondName; }
        public string LastName { get => lastName; }
        public DateTime Birthday { get => birthday; }
        public string Rfc { get => rfc; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        #region Constructors
        public Person()
        {

        }

        public Person(String name, String secondName, String lastName, DateTime birthday, String rfc)
        {
            this.name = name;
            this.secondName = secondName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.rfc = rfc;
        }

        public Person(String name, String secondName, String lastName, DateTime birthday, String rfc, String email, String phoneNumber) :
            this(name, secondName, lastName, birthday, rfc)
        {
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        #endregion

        public override String ToString()
        {
            return this.CreateMessageToString();
        }

        public String ToString(IFormatProvider formatProvider)
        {
            return this.CreateMessageToString(formatProvider);
        }

        private String CreateMessageToString(IFormatProvider formatProvider = null)
        {
            if (formatProvider == null)
            {
                this.messageToString = $"Hola, mi nombre es {this.name} {this.secondName} {this.lastName}. Nací el {this.birthday.ToString("D")}. Y mi RFC es: {this.rfc}.";
            }
            else
            {
                this.messageToString = $"Hola, mi nombre es {this.name} {this.secondName} {this.lastName}. Nací el {this.birthday.ToString("D", formatProvider)}. Y mi RFC es: {this.rfc}.";

            }

            if (String.IsNullOrEmpty(this.Email) == true && String.IsNullOrEmpty(this.PhoneNumber) == true)
            {
                return messageToString;
            }

            if (String.IsNullOrEmpty(this.Email) == false && String.IsNullOrEmpty(this.PhoneNumber) == true)
            {
                return $"{messageToString} Mi correo electrónico es: {this.Email}.";
            }

            if (String.IsNullOrEmpty(this.Email) == true && String.IsNullOrEmpty(this.PhoneNumber) == false)
            {
                return $"{messageToString} Mi correo número telefónico es: {this.PhoneNumber}.";
            }

            return $"{messageToString} Mi correo número telefónico es: {this.PhoneNumber}. Mi correo electrónico es: {this.Email}.";
        }
    }
}