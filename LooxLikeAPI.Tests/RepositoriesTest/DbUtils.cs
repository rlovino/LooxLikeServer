using System;

using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using Simple.Data;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
    class DbUtils
    {
        public static dynamic CreateConnection(string dbName, IList<string> createTables, IList<string> queries)
        {
            if (File.Exists(dbName))
                File.Delete(dbName);

            var en = new SqlCeEngine("Data Source = " + dbName);
            en.CreateDatabase();
            en.Dispose();
            var conn = new SqlCeConnection("Data Source = " + dbName);
            conn.Open();
            foreach (var createTable in createTables )
            {
                var comm = new SqlCeCommand(createTable, conn);
                Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            }
            foreach (var query in queries)
            {
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            return Database.OpenFile(dbName);
        }
    }
}
