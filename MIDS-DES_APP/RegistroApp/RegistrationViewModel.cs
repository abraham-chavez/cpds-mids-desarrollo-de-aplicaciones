using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegistroApp
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private Boolean newButtonVisibility;
        private Boolean editButtonVisibility;
        private Boolean deleteButtonVisibility;
        private Boolean saveButtonVisibility;
        private Boolean cancelButtonVisibility;
        private Boolean isEnabledControl;
        private Employee employee;
        private Int32 selectedIndex;
        #endregion

        #region Properties
        public bool NewButtonVisibility
        {
            get => this.newButtonVisibility;
            set
            {
                this.newButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool EditButtonVisibility
        {
            get => this.editButtonVisibility; set
            {
                this.editButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool DeleteButtonVisibility
        {
            get => this.deleteButtonVisibility; set
            {
                this.deleteButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool SaveButtonVisibility
        {
            get => this.saveButtonVisibility; set
            {
                this.saveButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool CancelButtonVisibility
        {
            get => this.cancelButtonVisibility; set
            {
                this.cancelButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsEnabledControl
        {
            get => this.isEnabledControl; set
            {
                this.isEnabledControl = value;
                this.OnPropertyChanged();
            }
        }

        public Employee Employee
        {
            get => this.employee; set
            {
                this.employee = value;
                this.OnPropertyChanged();
            }
        }
        public Int32 SelectedIndex
        {
            get => this.selectedIndex;
            set
            {
                this.selectedIndex = value;
                this.OnPropertyChanged();
                if (this.SelectedIndex >= 0)
                {
                    this.Employee = Employees[selectedIndex];
                }
                else
                {
                    this.Employee = new Employee() { Birthday = new DateTime(1980, 01, 01) };
                }
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public ICommand NewEmployeeCommand { get; set; }
        public ICommand SaveEmployeeCommand { get; set; }
        #endregion

        #region Constructors
        public RegistrationViewModel()
        {
            this.DisbaleEdition();
            this.Employees = new ObservableCollection<Employee>();
            this.NewEmployeeCommand = new ExecutionCommand(NewEmployee);
            this.SaveEmployeeCommand = new ExecutionCommand(SaveEmployee);
            this.SelectedIndex = -1;
        }
        #endregion

        #region Methods
        private void NewEmployee()
        {
            this.EnableEdition();
            this.Employee = new Employee() { EmployeeNumber = Guid.NewGuid().ToString(), Birthday = new DateTime(1980, 01, 01) };
        }

        private void SaveEmployee()
        {
            this.Employees.Add(this.employee);
            this.Employee = new Employee();
            this.DisbaleEdition();
        }

        private void EnableEdition()
        {
            this.NewButtonVisibility = false;
            this.EditButtonVisibility = false;
            this.DeleteButtonVisibility = false;
            this.SaveButtonVisibility = true;
            this.CancelButtonVisibility = true;
            this.IsEnabledControl = true;
        }

        private void DisbaleEdition()
        {
            this.NewButtonVisibility = true;
            this.EditButtonVisibility = true;
            this.DeleteButtonVisibility = true;
            this.SaveButtonVisibility = false;
            this.CancelButtonVisibility = false;
            this.IsEnabledControl = false;
        }

        public void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class ExecutionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;

        public ExecutionCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
