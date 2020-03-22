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

            this.GetEmployees();
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
            this.InsertEmployee();
            this.Employee = new Employee();
            this.DisbaleEdition();
            this.GetEmployees();
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

        private void InsertEmployee()
        {
            using (RegistroApp.DataContext.CPDSEntities context= new DataContext.CPDSEntities())
            {
                context.Employee.Add(new DataContext.Employee()
                {
                    Birthday = employee.Birthday,
                    Department = employee.Department,
                    Email = employee.Email,
                    JobMail = employee.JobEmail,
                    JobPhoneNumber = employee.JobPhoneNumber,
                    JobPosition = employee.JobPosition,
                    LastName = employee.LastName,
                    Name = employee.Name,
                    Password = employee.Password,
                    PhoneNumber = employee.PhoneNumber,
                    RFC = employee.Rfc,
                    SecondName = employee.SecondName
                });
                context.SaveChanges();
            }
        }

        private void GetEmployees()
        {
            this.Employees = new ObservableCollection<Employee>();
            using (RegistroApp.DataContext.CPDSEntities context = new RegistroApp.DataContext.CPDSEntities())
            {
                //var resultQuery = from emp in context.Employee.ToList() where emp.Department=="TI" select new { emp.Birthday };
                //var y = context.Employee.ToList().Select

                foreach (var item in context.Employee)
                {
                    this.Employees.Add(new Employee()
                    {
                        Birthday = item.Birthday,
                        Department = item.Department,
                        Email = item.Email,
                        EmployeeNumber = item.EmployeeID.ToString(),
                        JobEmail = item.JobMail,
                        JobPhoneNumber = item.JobPhoneNumber,
                        JobPosition = item.JobPosition,
                        LastName = item.LastName,
                        Name = item.Name,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        Rfc = item.RFC,
                        SecondName = item.SecondName
                    });
                }
            }

            this.OnPropertyChanged("Employees");
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
