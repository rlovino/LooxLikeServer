using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;
using Moq;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MappersTest
{
	[TestFixture]
	class PostMapperTest
	{

		private IPostMapper _sut;


		[SetUp]
		public void SetUp()
		{
			_sut = new PostMapper(new UserMapper());

		}

		[Test]
		public void TestConvertPostToDbPost()
		{
			var now = DateTime.Now;

			User user = new User
			{
				City = "city",
				DateOfBirth = now,
				Email = "email",
				FirstName = "firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "lastName",
				PictureUrl = "pictureUrl",
				UserName = "userName"
			};

			Post input = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = now,
				User = user
			};

			var expectedResult = new DbPost
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				Timestamp = now,
				UserId = 1
			};

			Assert.AreEqual(expectedResult, _sut.Convert(input));
		}


		[Test]
		public void TestConvertDbPostAndDbUserToPost()
        {
            var now = DateTime.Now;

            User user = new User
            {
                City = "city",
                DateOfBirth = now,
                Email = "email",
                FirstName = "firstName",
                Gender = User.Sex.Male,
                Id = 1,
                LastName = "lastName",
                PictureUrl = "pictureUrl",
                UserName = "userName"
            };

			var userSet = new HashSet<User>
			{
				new User
				{
					City = "city1",
					DateOfBirth = now,
					Email = "email1",
					FirstName = "firstName1",
					Gender = User.Sex.Male,
					Id = 2,
					LastName = "lastName1",
					PictureUrl = "pictureUrl1",
					UserName = "userName1"
				},
				new User
				{
					City = "city2",
					DateOfBirth = now,
					Email = "email2",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					UserName = "userName2"
				}
			};

            Post expectedResult = new Post
            {
                Id = 1,
                ItemId = "itemId",
                PhotoUrl = "photoUrl",
                Text = "text",
                TimeStamp = now,
                User = user,
				LikeUserEnumerable = userSet
            };

			

            var inputDbUser = new DbUser
            {
                Id = 1,
                City = "city",
                DateOfBirth = now,
                Email = "email",
                FirstName = "firstName",
                LastName = "lastName",
                PictureUrl = "pictureUrl",
                Sex = "m",
                UserName = "userName"
            };

            var inputdbPost = new DbPost
            {
                Id = 1,
                ItemId = "itemId",
                PhotoUrl = "photoUrl",
                Text = "text",
                Timestamp = now,
                UserId = 1
            };

			var inputDbUserList = new List<DbUser>
			{
				new DbUser
				{
					Id = 2,
					City = "city1",
					DateOfBirth = now,
					Email = "email1",
					FirstName = "firstName1",
					LastName = "lastName1",
					PictureUrl = "pictureUrl1",
					Sex = "m",
					UserName = "userName1"
				},
				new DbUser
				{
					Id = 3,
					City = "city2",
					DateOfBirth = now,
					Email = "email2",
					FirstName = "firstName2",
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					Sex = "m",
					UserName = "userName2"
				}
			};

            Assert.AreEqual(expectedResult,_sut.Convert(inputdbPost,inputDbUser,inputDbUserList));
        }

	}
}
