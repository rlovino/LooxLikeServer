using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MappersTest
{
	[TestFixture]
	class ResponseRequestLikePostMapperTest
	{
		private IResponseRequestLikePostMapper _sut;
		private readonly DateTime _now = DateTime.Now;

		[SetUp]
		public void SetUp()
		{
			_sut = new ResponseRequestLikePostMapper();
		}

		//public LikedUserPost Convert(User user, Post post)
		[Test]
		public void TestConvertToLikedUserPost()
		{
			User creatorUser = new User
			{
				City = "creator_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "creator_email",
				FirstName = "creator_firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "creator_lastName",
				PictureUrl = "creator_pictureUrl",
				UserName = "creator_userName"
			};

			var likeUsers = new HashSet<User>
			{
				new User
				{
					City = "city1",
					DateOfBirth = DateTime.Parse("1990-01-01"),
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
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "email2",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					UserName = "userName2"
				}
			};

			var newLikeUser = new User
			{
				City = "like_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "like_email",
				FirstName = "like_firstName",
				Gender = User.Sex.Male,
				Id = 4,
				LastName = "like_lastName",
				PictureUrl = "like_pictureUrl",
				UserName = "like_userName"
			};

			Post post = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = _now,
				User = creatorUser,
				LikeUserEnumerable = likeUsers
			};

			var expectedNewLikeUser = new User
			{
				City = "like_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "like_email",
				FirstName = "like_firstName",
				Gender = User.Sex.Male,
				Id = 4,
				LastName = "like_lastName",
				PictureUrl = "like_pictureUrl",
				UserName = "like_userName"
			};

			User expectedCreatorUser = new User
			{
				City = "creator_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "creator_email",
				FirstName = "creator_firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "creator_lastName",
				PictureUrl = "creator_pictureUrl",
				UserName = "creator_userName"
			};
			HashSet<User> expectedLikeUsers = new HashSet<User>
			{
				new User
				{
					City = "city1",
					DateOfBirth = DateTime.Parse("1990-01-01"),
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
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "email2",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					UserName = "userName2"
				}
			};
			var expected = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = new Post
				{
					Id = 1,
					ItemId = "itemId",
					PhotoUrl = "photoUrl",
					Text = "text",
					TimeStamp = _now,
					LikeUserEnumerable = expectedLikeUsers,
					User = expectedCreatorUser
				},
				User = expectedNewLikeUser
			};

			var actual = _sut.Convert(newLikeUser, post);

			Assert.AreEqual(expected, actual);

		}

		//public JsonLikeResponse Convert(LikedUserPost likedUserPost)
		[Test]
		public void TestConvertLikedUserPostToJsonLikeResponse()
		{
			User creatorUserToTest = new User
			{
				City = "creator_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "creator_email",
				FirstName = "creator_firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "creator_lastName",
				PictureUrl = "creator_pictureUrl",
				UserName = "creator_userName"
			};
			HashSet<User> likeUsersListToTest = new HashSet<User>
			{
				new User
				{
					City = "city1",
					DateOfBirth = DateTime.Parse("1990-01-01"),
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
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "email2",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					UserName = "userName2"
				}
			};
			Post postToTest = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = _now,
				LikeUserEnumerable = likeUsersListToTest,
				User = creatorUserToTest
			};
			User likeUserToTest = new User
			{
				City = "like_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "like_email",
				FirstName = "like_firstName",
				Gender = User.Sex.Male,
				Id = 4,
				LastName = "like_lastName",
				PictureUrl = "like_pictureUrl",
				UserName = "like_userName"
			};
			var input = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = postToTest,
				User = likeUserToTest
			};

			var expected = new JsonLikeResponse
			{
				likedDateTime = _now,
				likedPostId = 1,
				username = "like_userName"
			};

			var actual = _sut.Convert(input);

			Assert.AreEqual(expected, actual);
		}

	}
}
