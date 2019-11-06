using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSQLite_UWP.Utils
{
    class SQLiteUtil
    {
        private const string DatabaseName = "UWPContact.db";

        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }
            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS AddContact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ),Phone VARCHAR( 140 ));";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
           
        }
    }
}
