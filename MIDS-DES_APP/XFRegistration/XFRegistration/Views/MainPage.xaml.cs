using SQLite;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFRegistration.DataAccess;

namespace XFRegistration.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        private SQLiteAsyncConnection sqliteConn;

        public MainPage()
        {
            InitializeComponent();
            this.sqliteConn = DependencyService.Get<ISQLiteDB>().GetConnection();

            Task.Run(async ()=>
            {
                var result = await sqliteConn.InsertAsync(new T_Log()
                {
                    Date = DateTime.Now,
                    Module = "Mainpage",
                    Operation = "El usuario inició la aplicación"
                }, typeof(T_Log));
            });
        }
    }
}