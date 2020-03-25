using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFRegistration.Models;
using XFRegistration.ViewModels;

namespace XFRegistration.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            this.viewModel.SaveEmployeeFinished = SaveEmployeeFinished;
        }
        private async void SaveEmployeeFinished(Boolean status, String message)
        {
            await this.DisplayAlert("Guardar Empleado", message, "Aceptar");
        }
    }
}