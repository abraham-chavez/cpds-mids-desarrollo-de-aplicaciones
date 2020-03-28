using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFRegistration.DataAccess
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}