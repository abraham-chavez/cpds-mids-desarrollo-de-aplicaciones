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
        #region Fields
        private ObservableCollection<Employee> employees;
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
        #endregion

        #region Constructors
        public ItemsViewModel()
        {
            base.Title = "Empleados";
            this.Employees = new ObservableCollection<Employee>();
            this.LoadEmplpoyeesCommand = new Command(async () => await ExecuteLoadEmployeesCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                //Employees.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }
        #endregion

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