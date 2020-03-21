using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities
{
    public sealed class Employee : Person
    {
        #region Fields
        private String employeeNumber;
        private String department;
        private String jobPosition;
        private String jobEmail;
        private String jobPhoneNumber;
        private String password;
        #endregion

        #region Properties
        public String EmployeeNumber { get => this.employeeNumber;
            set
            {
                this.employeeNumber = value;
                this.OnPropertyChanged();
            }
        }
        public String JobEmail { get => this.jobEmail;
            set
            {
                this.jobEmail = value;
                this.OnPropertyChanged();
            }
        }
        public String Department
        {
            get => this.department;
            set
            {
                this.department = value;
                base.OnPropertyChanged();
            }
        }
        public String JobPosition
        {
            get => this.jobPosition;
            set
            {
                this.jobPosition = value;
                base.OnPropertyChanged();
            }
        }
        public String JobPhoneNumber
        {
            get => this.jobPhoneNumber;
            set
            {
                this.jobPhoneNumber = value;
                base.OnPropertyChanged();
            }
        }
        public String Password
        {
            get => this.password;
            set
            {
                this.password = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public Employee()
        {

        }
        #endregion

        #region Methods
        private void GenerateJobEmail()
        {
            Regex reg = new Regex("[^a-zA-Z0-9]");

            String normalizedName = reg.Replace(base.Name.ToLower().Normalize(NormalizationForm.FormD), "");
            String normalizationLastName = reg.Replace(base.LastName.ToLower().Split(' ')[0].Normalize(NormalizationForm.FormD), "");

            this.jobEmail = $"{normalizedName}.{normalizationLastName}@myapp.com";
        }
        #endregion
    }
}