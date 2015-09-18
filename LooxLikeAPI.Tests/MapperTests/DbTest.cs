using System;
using System.Data.SqlServerCe;
using System.IO;
using LooxLikeAPI.Models;
using LooxLikeAPI.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
       


        [SetUp]
        public void setUp()
        {
            string fileName = "testdb.sdf";
	        if (File.Exists(fileName))
	           File.Delete(fileName);

            SqlCeEngine _en = new SqlCeEngine("Data Source = " + fileName);
            _en.CreateDatabase();
            _en.Dispose();
            SqlCeConnection conn = new SqlCeConnection("Data Source = " + fileName);
            conn.Open();
            SqlCeCommand comm = new SqlCeCommand("create table Post (id bigint identity(1,1) primary key, message nvarchar(100))", conn);
            Console.WriteLine("Response: " + comm.ExecuteNonQuery());
            conn.Close();
            
            var db = Database.OpenFile(fileName);
            _sut = new PostRepository(db);
        }



        [Test]
        public void TestReadPostMessage()
        {
            var post = new Post { Message = "test" };
            var id = _sut.save(post);
            var expectedResult = new Post { Message = "test" };

            Assert.AreEqual(expectedResult.Message, _sut.read(id).Message);

        }

        [TearDown]
        public void tearDown()
        {
        }

       

      

       
    }
}
