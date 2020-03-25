using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFRegistration.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Task.Run(async ()=> this.userEmail.Text = await SecureStorage.GetAsync("UserEmail"));

            Task.Run(async () => this.userPhoneNumber.Text = await SecureStorage.GetAsync("UserPhoneNumber"));
        }

        private async void SaveUserData_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.SetAsync("UserEmail", userEmail.Text);
            await SecureStorage.SetAsync("UserPhoneNumber", userPhoneNumber.Text);
            await SecureStorage.SetAsync("UserPassword", userPassword.Text);

            await this.DisplayAlert("Registro", "Los datos se guardaron correctamente", "Aceptar");
        }
    }
}