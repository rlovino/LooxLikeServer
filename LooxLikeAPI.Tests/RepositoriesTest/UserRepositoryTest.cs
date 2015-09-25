using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Repository;
using LooxLikeAPI.Tests.MapperTests;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
    [TestFixture]
    class UserRepositoryTest
    {

        private IUserRepository _sut;
        private dynamic connection;
        private readonly string createTable = "create table users (id bigint identity(1,1) primary key," +
            "user_name nvarchar(32) not null," +
            "first_name nvarchar(32) not null," +
            "last_name nvarchar(32) not null," +
            "sex nvarchar(1) not null," +
            "email nvarchar(64) not null," +
            "date_of_birth datetime not null," +
            "city nvarchar(64) null," +
            "picture_url nvarchar(128) not null)";

        [SetUp]
        public void setUp()
        {
            connection = DbUtils.createConnection("TestDbUserRepository.sdf", createTable);
            _sut = new UserRepository(connection);
        }



        [Test]
        public void TestReadUser()
        {
            var now = DateTime.Now;
            DbUser dbUser = new DbUser{City = "city", DateOfBirth = now, Email = "email@email.com",FirstName = "firstName",LastName = "lastName",PictureUrl = "pictureUrl",Sex = "m",UserName = "userName"};

            long id = _sut.save(dbUser);
            var readed = _sut.read(id);

            Assert.AreEqual(dbUser.City,readed.City);
            Assert.AreEqual(dbUser.DateOfBirth.Date, readed.DateOfBirth.Date);
            Assert.AreEqual(dbUser.Email, readed.Email);
            Assert.AreEqual(dbUser.FirstName, readed.FirstName);
            Assert.AreEqual(dbUser.LastName, readed.LastName);
            Assert.AreEqual(dbUser.PictureUrl, readed.PictureUrl);
            Assert.AreEqual(dbUser.Sex, readed.Sex);
            Assert.AreEqual(dbUser.UserName, readed.UserName);


        }
    }
}


