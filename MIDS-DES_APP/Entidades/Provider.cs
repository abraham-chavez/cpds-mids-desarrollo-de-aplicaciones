using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provider : Person
    {
        #region Fields
        private String company;
        private String contactNumber;
        private String contactEmail;
        private String address;
        private String providerID;
        #endregion

        #region Properties
        public string Company { get => company; }
        public string ProviderID { get => providerID; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string ContactEmail { get => contactEmail; set => contactEmail = value; }
        public string Address { get => address; set => address = value; }
        #endregion

        #region Constructors
        public Provider(String providerID, String company) : base()
        {
            this.providerID = providerID;
            this.company = company;
        }

        public Provider(String name, String secondName, String lastName, DateTime birthday, String rfc, String providerID, String company) :
            base(name, secondName, lastName, birthday, rfc)
        {
            this.providerID = providerID;
            this.company = company;
        }

        public Provider(String name, String secondName, String lastName, DateTime birthday, String rfc, String email, String phoneNumber, String providerID, String company) :
            base(name, secondName, lastName, birthday, rfc, email, phoneNumber)
        {
            this.providerID = providerID;
            this.company = company;
        }
        #endregion

        public override string ExapleMethodAbstract()
        {
            return "Este es un mensaje desde el método ExapleMethodAbstract de la clase Provider";
        }
    }

    public class SubProvider : Provider
    {
        #region Constructors
        public SubProvider(String providerID, String company) : base(providerID, company)
        {
        }

        public SubProvider(String name, String secondName, String lastName, DateTime birthday, String rfc, String providerID, String company) :
            base(name, secondName, lastName, birthday, rfc, providerID, company)
        {
        }

        public SubProvider(String name, String secondName, String lastName, DateTime birthday, String rfc, String email, String phoneNumber, String providerID, String company) :
            base(name, secondName, lastName, birthday, rfc, email, phoneNumber, providerID, company)
        {
        }
        #endregion

        public override string ExapleMethodAbstract()
        {
            return "Este es un mensaje desde el método ExapleMethodAbstract de la clase SubProvider";
        }
    }
}