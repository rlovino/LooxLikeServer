using System;
using System.Data.SqlServerCe;
using System.IO;
using LooxLikeAPI.Models;
using LooxLikeAPI.Repository;
using NUnit.Framework;
using Simple.Data;
using Assert = NUnit.Framework.Assert;

namespace LooxLikeAPI.Tests.MapperTests
{
    [TestFixture]
    public class DbTest
    {
        private IPostRepository _sut;
        private SqlCeEngine _en;
        private const string DATABASE_NAME = "testdb.sdf" ;
        private dynamic connection;


        [TestFixtureSetUp]
        public void setUpAllTest()
        {
            if (File.Exists(DATABASE_NAME))
                File.Delete(DATABASE_NAME);

            SqlCeEngine _en = new SqlCeEngine("Data Source = " + DATABASE_NAME);
            _en.CreateDatabase();
            _en.Dispose();
            SqlCeConnection conn = new SqlCeConnection("Data Source = " + DATABASE_NAME);
            conn.Open();
            SqlCeCommand comm = new SqlCeCommand("create table Post (id bigint identity(1,1) primary key, message nvarchar(100))", conn);
            Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            conn.Close();
        }



        [SetUp]
        public void setUp()
        {
            connection = Database.OpenFile(DATABASE_NAME);
            _sut = new PostRepository(connection);
        }



        [Test]
        public void TestReadPostMessage()
        {
            var post = new Post { Message = "test" };
            var id = _sut.save(post);
            var expectedResult = new Post { Message = "test" };
            Assert.AreEqual(expectedResult.Message, _sut.read(id).Message);

        }

       
    }
}
