using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFRegistration.DataAccess
{
    [Table("Log")]
    public class T_Log
    {
        [PrimaryKey, AutoIncrement]
        public Int32 T_LogID { get; set; }
        
        public DateTime Date { get; set; }
        
        [MaxLength(100)]
        public String Module { get; set; }

        [MaxLength(100)]
        public String Operation { get; set; }
    }
}