using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFRegistration.Entities;

namespace XFRegistration.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public delegate void SaveEmployeeFinishedDelegate(Boolean estatus, String message);

        #region Fields
        public SaveEmployeeFinishedDelegate SaveEmployeeFinished;
        #endregion

        #region Properties
        public Employee Employee { get; set; }
        public Command SaveEmployeeCommand { get; set; }
        #endregion

        #region Constructors
        public NewItemViewModel()
        {
            this.Employee = new Employee() { Birthday = new DateTime(1990, 01, 01) };
            this.SaveEmployeeCommand = new Command(async () => await SaveEmployee());
        }
        #endregion

        #region Methods
        private async Task SaveEmployee()
        {
            HttpClient httpClient = new HttpClient();

            var resutl = await httpClient.PostAsync("https://desarrollodeaplicacionescpds.azurewebsites.net/api/Employee",
                new StringContent(JsonConvert.SerializeObject(this.Employee), Encoding.UTF8, "application/json"));

            if (resutl.IsSuccessStatusCode == true)
            {
                this.SaveEmployeeFinished(true, "El empleado se guardó correctamente");
            }
            else
            {
                this.SaveEmployeeFinished(false, "Ocurrió un error al intentar guardar el empleado");
            }
        }
        #endregion
    }
}