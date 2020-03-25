using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using XFRegistration.Entities;
using XFRegistration.Models;
using XFRegistration.Views;

namespace XFRegistration.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public delegate void DeleteEmployeeCompletedDelegate(Boolean status, String message);

        #region Fields
        private ObservableCollection<Employee> employees;
        public DeleteEmployeeCompletedDelegate DeleteEmployeeCompleted;
        #endregion

        #region Properties
        public ObservableCollection<Employee> Employees
        {
            get => this.employees;
            set
            {
                this.employees = value;
                base.OnPropertyChanged();
            }
        }

        public Command LoadEmplpoyeesCommand { get; set; }
        public Command DeleteEmployeeCommand { get; set; }
        #endregion

        #region Constructors
        public ItemsViewModel()
        {
            base.Title = "Empleados";
            this.Employees = new ObservableCollection<Employee>();
            this.LoadEmplpoyeesCommand = new Command(async () => await ExecuteLoadEmployeesCommand());
            this.DeleteEmployeeCommand = new Command(async (emp) => await DeleteEmployee(emp));

            MessagingCenter.Subscribe<NewItemPage, Employee>(this, "AddItem", async (obj, item) =>
            {
                await this.ExecuteLoadEmployeesCommand();
            });
        }
        #endregion

        private async Task DeleteEmployee(Object employee)
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.DeleteAsync($"https://desarrollodeaplicacionescpds.azurewebsites.net/api/Employee/{(employee as Employee).EmployeeNumber}");

            if (result.IsSuccessStatusCode == true)
            {
                this.DeleteEmployeeCompleted(true, "El empleado fue eliminado correctamente");
                await this.ExecuteLoadEmployeesCommand();
            }
            else
            {
                this.DeleteEmployeeCompleted(false, "Ocurrió un error al intentar eliminar el empleado");
            }
        }

        private async Task ExecuteLoadEmployeesCommand()
        {
            base.IsBusy = true;

            try
            {
                Employees.Clear();
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetAsync("https://desarrollodeaplicacionescpds.azurewebsites.net/api/Employee");

                if (result.IsSuccessStatusCode == true)
                {
                    var webEmployees = await result.Content.ReadAsStringAsync();
                    this.Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(webEmployees);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}