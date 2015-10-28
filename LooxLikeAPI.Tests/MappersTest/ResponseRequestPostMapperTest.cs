using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Models.JSONModel.Request;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Tests.MappersTest
{
	[TestFixture]
	class ResponseRequestPostMapperTest
	{
		private IResponseRequestPostMapper _sut;
		readonly DateTime _now = DateTime.Now;

		[SetUp]
		public void SetUp()
		{
			_sut = new ResponseRequestPostMapper();
		}

		[Test]
		public void ConvertPostToJsonPostResponseIfLiked()
		{
			var likeUserSet = new HashSet<User>
			{
				new User{
					City = "city1", 
					UserName = "userName1", 
					DateOfBirth = DateTime.Parse("1990-01-01").Date,
					Email = "user1@gmail.com",
					FirstName = "firstName1",
					Gender = User.Sex.Male,
					Id = 2,
					LastName = "lastName1",
					PictureUrl = "pictureUrl1"
				},
				new User{
					City = "city2", 
					UserName = "userName2", 
					DateOfBirth = DateTime.Parse("1990-01-01").Date,
					Email = "user2@gmail.com",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2"
				}
			};

			var user = new User
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
			
			var input = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = _now,
				User = user,
				LikeUserEnumerable = likeUserSet
			};

			var expectedResult = new JsonPostResponse
			{
				C10 = "itemId",
				CreationTime = _now,
				Description = "text",
				Liked = true,
				NumLikes = 2,
				PhotoUrl = "photoUrl",
				PostId = 1,
				UserName = "userName"
			};

			Assert.AreEqual(expectedResult, _sut.Convert(input, "userName1"));
		}


        [Test]
        public void ConvertListOfPostToListOfJsonPostResponse()
        {
            var likeUserSet = new HashSet<User>
			{
				new User{
					City = "city1", 
					UserName = "userName1", 
					DateOfBirth = DateTime.Parse("1990-01-01").Date,
					Email = "user1@gmail.com",
					FirstName = "firstName1",
					Gender = User.Sex.Male,
					Id = 2,
					LastName = "lastName1",
					PictureUrl = "pictureUrl1"
				},
				new User{
					City = "city2", 
					UserName = "userName2", 
					DateOfBirth = DateTime.Parse("1990-01-01").Date,
					Email = "user2@gmail.com",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2"
				}
			};

            var user = new User
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

            var input = new List<Post> {
                new Post {
                    Id = 1,
                    ItemId = "itemId",
                    PhotoUrl = "photoUrl",
                    Text = "text",
                    TimeStamp = _now,
                    User = user,
                    LikeUserEnumerable = likeUserSet
                }
            };

            var expectedResult = new List<JsonPostResponse> { 
                new JsonPostResponse {
                    C10 = "itemId",
                    CreationTime = _now,
                    Description = "text",
                    Liked = true,
                    NumLikes = 2,
                    PhotoUrl = "photoUrl",
                    PostId = 1,
                    UserName = "userName"
                }
            };

            Assert.AreEqual(expectedResult, _sut.Convert(input, "userName1"));

        }

		[Test]
		public void TestConvertToPost()
		{
			var user = new User
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

			var input = new PostRequest
			{
				C10 = "c10",
				Description = "description",
				Image = null,
			};

			var photoUrl = "photoUrlToTest";

			var expectedResult = new Post
			{
				ItemId = "c10",
				PhotoUrl = "photoUrlToTest",
				Text = "description",
				User = user,
				LikeUserEnumerable = new HashSet<User>()
			};

			var actual = _sut.Convert(input, photoUrl, user);

			Assert.AreEqual(expectedResult,actual);

		}

	}
}
