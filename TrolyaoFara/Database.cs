using System;
using System.Data.SQLite;
using System.IO;

namespace TrolyaoFara
{
    class Database
    {
        public SQLiteConnection myConnection;
        LibFunction lib = new LibFunction();

        public Database()
        {
            string path = lib.getPathDataInPCUser(@"\.faraVN");
            string dbpath = path + "/database.sqlite";

            myConnection = new SQLiteConnection(string.Format("Data Source={0}", dbpath));
            if (!File.Exists(dbpath))
            {
                SQLiteConnection.CreateFile(dbpath);
            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if(myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public void RunSQL(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, myConnection);
            OpenConnection();
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

    }
}
