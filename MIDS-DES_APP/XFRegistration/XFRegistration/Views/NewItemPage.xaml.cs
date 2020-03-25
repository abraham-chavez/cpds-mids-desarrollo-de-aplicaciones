using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFRegistration.Models;
using XFRegistration.ViewModels;

namespace XFRegistration.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        private NewItemViewModel context;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = context = new NewItemViewModel();
            context.SaveEmployeeFinished = SaveEmployeeFinished;
        }

        private async void SaveEmployeeFinished(Boolean status, String message)
        {
            await this.DisplayAlert("Guardar Empleado", message, "Aceptar");

            if (status == true)
            {
                MessagingCenter.Send(this, "AddItem", context.Employee);
                await Navigation.PopModalAsync();
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}