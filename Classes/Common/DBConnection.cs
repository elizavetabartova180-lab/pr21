using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Bartova.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"C:\Users\PC\Downloads\pr21-master\pr21-master\bin\Debug\DataBase.accbd";
        public static OleDbConnection Connection()
        {
            OleDbConnection connection = new OleDbConnection(Path);
            connection.Open();
            return connection;
        }
        public static OleDbDataReader Querty (string sql, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(sql, connection);
            return command.ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection connection) { 
            connection.Close();
        }
    }
}
