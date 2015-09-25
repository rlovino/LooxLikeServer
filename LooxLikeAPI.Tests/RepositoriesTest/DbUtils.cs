using System;
using System.Data.SqlServerCe;
using System.IO;
using Simple.Data;

namespace LooxLikeAPI.Tests.MapperTests
{
    class DbUtils
    {
        private const String DATABASE_NAME = "testdb";
        public static dynamic createConnection(String createTable)
        {
            if(File.Exists(DATABASE_NAME))
                File.Delete(DATABASE_NAME);

            SqlCeEngine _en = new SqlCeEngine("Data Source = " + DATABASE_NAME);
            _en.CreateDatabase();
            _en.Dispose();
            SqlCeConnection conn = new SqlCeConnection("Data Source = " + DATABASE_NAME);
            conn.Open();
            SqlCeCommand comm = new SqlCeCommand(createTable, conn);
            Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            conn.Close();
            return Database.OpenFile(DATABASE_NAME);
        }
    }
}
