using System;
using System.Data.SqlServerCe;
using System.IO;
using Simple.Data;

namespace LooxLikeAPI.Tests.MapperTests
{
    class DbUtils
    {
        public static dynamic createConnection(String dbName, String createTable)
        {
            if (File.Exists(dbName))
                File.Delete(dbName);

            SqlCeEngine _en = new SqlCeEngine("Data Source = " + dbName);
            _en.CreateDatabase();
            _en.Dispose();
            SqlCeConnection conn = new SqlCeConnection("Data Source = " + dbName);
            conn.Open();
            SqlCeCommand comm = new SqlCeCommand(createTable, conn);
            Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            conn.Close();
            return Database.OpenFile(dbName);
        }
    }
}
