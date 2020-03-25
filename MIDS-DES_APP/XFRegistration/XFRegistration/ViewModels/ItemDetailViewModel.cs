using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFRegistration.Entities;
using XFRegistration.Models;

namespace XFRegistration.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public delegate void SaveEmployeeFinishedDelegate(Boolean estatus, String message);

        #region Fields
        private Boolean isLableVisible;
        private Boolean isEntryVisible;
        private String originalEmployee;
        private Employee employee;
        public SaveEmployeeFinishedDelegate SaveEmployeeFinished;
        #endregion

        #region Properties
        public Employee Employee
        {
            get => this.employee;
            set
            {
                this.employee = value;
                base.OnPropertyChanged();
            }
        }

        public bool IsLableVisible
        {
            get => this.isLableVisible;
            set
            {
                this.isLableVisible = value;
                base.OnPropertyChanged();
            }
        }

        public bool IsEntryVisible
        {
            get => this.isEntryVisible;
            set
            {
                this.isEntryVisible = value;
                base.OnPropertyChanged();
            }
        }

        public Command EditEmployeeCommand { get; set; }
        public Command CancelEditEmployeeCommand { get; set; }
        public Command SaveEditEmployeeCommand { get; set; }
        #endregion

        #region Constructors
        public ItemDetailViewModel(Employee employee)
        {
            this.originalEmployee = JsonConvert.SerializeObject(employee);

            this.employee = employee;
            base.Title = "Editar empleado";

            this.IsEntryVisible = false;
            this.IsLableVisible = true;

            this.EditEmployeeCommand = new Command(() => EdithEmployee());
            this.CancelEditEmployeeCommand = new Command(() => CancelEditEmployee());
            this.SaveEditEmployeeCommand = new Command(async () => await SaveEditEmployee());
        }
        #endregion

        #region Methods
        private void EdithEmployee()
        {
            this.IsEntryVisible = true;
            this.IsLableVisible = false;
        }

        private void CancelEditEmployee()
        {
            this.Employee = JsonConvert.DeserializeObject<Employee>(this.originalEmployee);

            this.IsEntryVisible = false;
            this.IsLableVisible = true;
        }

        private async Task SaveEditEmployee()
        {
            HttpClient httpClient = new HttpClient();

            var resutl = await httpClient.PutAsync("https://desarrollodeaplicacionescpds.azurewebsites.net/api/Employee",
                new StringContent(JsonConvert.SerializeObject(this.Employee), Encoding.UTF8, "application/json"));

            if (resutl.IsSuccessStatusCode == true)
            {
                this.SaveEmployeeFinished(true, "El actualizó se guardó correctamente");
                this.originalEmployee = JsonConvert.SerializeObject(employee);
                this.IsEntryVisible = false;
                this.IsLableVisible = true;
            }
            else
            {
                this.SaveEmployeeFinished(false, "Ocurrió un error al intentar actualizar el empleado");
            }
        }
        #endregion
    }
}