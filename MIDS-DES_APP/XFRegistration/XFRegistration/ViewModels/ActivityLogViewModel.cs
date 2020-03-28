using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFRegistration.DataAccess;

namespace XFRegistration.ViewModels
{
    public class ActivityLogViewModel : BaseViewModel
    {
        ObservableCollection<T_Log> logs;

        public ObservableCollection<T_Log> Logs
        {
            get => this.logs;
            set
            {
                this.logs = value;
            }
        }

        public ActivityLogViewModel()
        {
            SQLiteAsyncConnection conn = DependencyService.Get<ISQLiteDB>().GetConnection();

            Task.Run(async ()=>
            {
                var result = await conn.QueryAsync<T_Log>("SELECT * FROM Log");

                this.logs = new ObservableCollection<T_Log>(result);
            });
        }
    }
}