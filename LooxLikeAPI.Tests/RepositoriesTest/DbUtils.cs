using System;
using System.Data.SqlServerCe;
using System.IO;
using Simple.Data;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
    class DbUtils
    {
        public static dynamic CreateConnection(string dbName, string createTable)
        {
            if (File.Exists(dbName))
                File.Delete(dbName);

            var en = new SqlCeEngine("Data Source = " + dbName);
            en.CreateDatabase();
            en.Dispose();
            var conn = new SqlCeConnection("Data Source = " + dbName);
            conn.Open();
            var comm = new SqlCeCommand(createTable, conn);
            Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            conn.Close();
            return Database.OpenFile(dbName);
        }
    }
}
