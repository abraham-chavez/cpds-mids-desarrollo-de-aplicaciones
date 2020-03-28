using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFRegistration.ViewModels;

namespace XFRegistration.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityLog : ContentPage
    {
        public ActivityLog()
        {
            InitializeComponent();

            this.BindingContext = new ActivityLogViewModel();
        }

        private async void Clode_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}