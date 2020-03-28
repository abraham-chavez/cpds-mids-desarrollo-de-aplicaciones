using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;
using XFRegistration.DataAccess;
using XFRegistration.Droid;

[assembly: Dependency(typeof(SQLiteDB))]
namespace XFRegistration.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            return new SQLiteAsyncConnection(Path.Combine(documentsPath, "MySQLite.db3"));
        }
    }
}