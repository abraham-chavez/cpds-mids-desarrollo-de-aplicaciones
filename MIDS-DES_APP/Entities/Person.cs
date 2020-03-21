using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Entities
{
    public abstract class Person : INotifyPropertyChanged
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
        #endregion

        #region Constructors
        public Person()
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