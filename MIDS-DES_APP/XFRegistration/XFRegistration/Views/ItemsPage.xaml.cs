using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFRegistration.Models;
using XFRegistration.Views;
using XFRegistration.ViewModels;

namespace XFRegistration.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {

        public ItemsPage()
        {
            InitializeComponent();
            (this.BindingContext as ItemsViewModel).DeleteEmployeeCompleted = DeleteEmployeeCompleted;
        }

        private async void DeleteEmployeeCompleted(Boolean status, String message)
        {
            await this.DisplayAlert("Eliminar empleado", message, "Aceptar");
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if ((this.BindingContext as ItemsViewModel).Employees.Count == 0)
                (this.BindingContext as ItemsViewModel).IsBusy = true;
        }
    }
}