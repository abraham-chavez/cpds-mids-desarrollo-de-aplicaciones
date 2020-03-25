using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XFRegistration.Entities
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        private String name;
        private String secondName;
        private String lastName;
        private DateTime birthday;
        private String rfc;
        private String email;
        private String phoneNumber;
        private Int32 employeeNumber;
        private String department;
        private String jobPosition;
        private String jobEmail;
        private String jobPhoneNumber;
        private String password;
        #endregion

        #region Properties
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnPropertyChanged();
            }
        }
        public string SecondName
        {
            get => this.secondName;
            set
            {
                this.secondName = value;
                this.OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                this.OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => $"{this.name} {this.secondName} {this.lastName}";
        }
        public DateTime Birthday
        {
            get => this.birthday;
            set
            {
                this.birthday = value;
                this.OnPropertyChanged();
            }
        }
        public string Rfc
        {
            get => this.rfc;
            set
            {
                this.rfc = value;
                this.OnPropertyChanged();
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
                this.OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                this.phoneNumber = value;
                this.OnPropertyChanged();
            }
        }
        public Int32 EmployeeNumber
        {
            get => this.employeeNumber;
            set
            {
                this.employeeNumber = value;
                this.OnPropertyChanged();
            }
        }
        public String JobEmail
        {
            get => this.jobEmail;
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
                this.OnPropertyChanged();
            }
        }
        public String JobPosition
        {
            get => this.jobPosition;
            set
            {
                this.jobPosition = value;
                this.OnPropertyChanged();
            }
        }
        public String JobPhoneNumber
        {
            get => this.jobPhoneNumber;
            set
            {
                this.jobPhoneNumber = value;
                this.OnPropertyChanged();
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

        public String PhotoURL
        {
            get => $"profile0{new Random().Next(1, 8)}.png";
        }
        #endregion

        #region Constructors
        public Employee()
        {
        }
        #endregion

        #region Methods
        public void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}