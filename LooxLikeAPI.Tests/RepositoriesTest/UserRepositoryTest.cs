using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
    [TestFixture]
    class UserRepositoryTest
    {

        private IUserRepository _sut;
        private IUserMapper _mapper;
        private dynamic _connection;
		private const string CreateTableUsers =
			"create table users " +
			"(id bigint identity(1,1) primary key," +
			"user_name nvarchar(32) not null," +
			"first_name nvarchar(32) not null," +
			"last_name nvarchar(32) not null," +
			"sex nvarchar(1) not null," +
			"email nvarchar(30) not null," +
			"date_of_birth datetime null," +
			"city nvarchar(64) null," +
			"picture_url nvarchar(123) not null) ";

		private const string InsertUser =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
			"values ('userName','firstName','lastName','m','user@gmail.com','1990-01-01','city','pictureUrl') ";

        [SetUp]
        public void SetUp()
        {
            var tables = new List<string> { CreateTableUsers };
            var inserts = new List<string> { InsertUser };
            _mapper = new UserMapper();
            _connection = DbUtils.CreateConnection("TestDbUserRepository.sdf", tables, inserts);
            _sut = new UserRepository(_connection,_mapper);
        }



        [Test]
        public void TestReadUser()
        {
			var expectedUser = new User
			{
				City = "city",
				UserName = "userName",
				DateOfBirth = DateTime.Parse("1990-01-01").Date,
				Email = "user@gmail.com",
				FirstName = "firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "lastName",
				PictureUrl = "pictureUrl"
			};

			const int userId = 1;
	        var actual = _sut.Read(userId);
	        Assert.AreEqual(expectedUser.City, actual.City);
			Assert.AreEqual(expectedUser.DateOfBirth.Date, actual.DateOfBirth.Date);
			Assert.AreEqual(expectedUser.Email, actual.Email);
			Assert.AreEqual(expectedUser.FirstName, actual.FirstName);
			Assert.AreEqual(expectedUser.LastName, actual.LastName);
			Assert.AreEqual(expectedUser.PictureUrl, actual.PictureUrl);
			Assert.AreEqual(expectedUser.Gender, actual.Gender);
			Assert.AreEqual(expectedUser.UserName, actual.UserName);
        }
    }
}


