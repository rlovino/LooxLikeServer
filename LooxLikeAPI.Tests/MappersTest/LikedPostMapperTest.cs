using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Models.Model.Mapper;
using NUnit;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MappersTest
{
	[TestFixture]
	class LikedPostMapperTest
	{
		private ILikedPostMapper _sut;
		private DateTime _now = DateTime.Now;

		[SetUp]
		public void SetUp()
		{
			_sut = new LikedPostMapper();
		}

		[Test]
		public void TestConvertPostAndUserToLikedUserPost()
		{
			User postCreatorUser = new User
			{
				City = "creator_city",
				DateOfBirth = _now.Date,
				Email = "creator_email",
				FirstName = "creator_firstName",
				LastName = "creator_lastName",
				Gender = User.Sex.Male,
				Id = 1,
				PictureUrl = "creator_pictureUrl",
				UserName = "creator_userName"
			};

			User requesterUser = new User
			{
				City = "requester_city",
				DateOfBirth = _now.Date,
				Email = "requester_email",
				FirstName = "requester_firstName",
				LastName = "requester_lastName",
				Gender = User.Sex.Male,
				Id = 2,
				PictureUrl = "requester_pictureUrl",
				UserName = "requester_userName"
			};

			var likeUserSet = new HashSet<User>
			{
				new User{
					City = "city1", 
					UserName = "userName1", 
					DateOfBirth = DateTime.Parse("1990-01-01").Date,
					Email = "user1@gmail.com",
					FirstName = "firstName1",
					Gender = User.Sex.Male,
					Id = 3,
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
					Id = 4,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2"
				}
			};

			var input = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = _now,
				User = postCreatorUser,
				LikeUserEnumerable = likeUserSet
			};


			var expected = new LikedUserPost
			{
				Post = new Post
				{
					Id = 1,
					ItemId = "itemId",
					PhotoUrl = "photoUrl",
					Text = "text",
					TimeStamp = _now,
					User = new User
					{
						City = "creator_city",
						DateOfBirth = _now.Date,
						Email = "creator_email",
						FirstName = "creator_firstName",
						LastName = "creator_lastName",
						Gender = User.Sex.Male,
						Id = 1,
						PictureUrl = "creator_pictureUrl",
						UserName = "creator_userName"
					},
					LikeUserEnumerable = new HashSet<User>
					{
						new User{
							City = "city1", 
							UserName = "userName1", 
							DateOfBirth = DateTime.Parse("1990-01-01").Date,
							Email = "user1@gmail.com",
							FirstName = "firstName1",
							Gender = User.Sex.Male,
							Id = 3,
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
							Id = 4,
							LastName = "lastName2",
							PictureUrl = "pictureUrl2"
						}
					}
				},
				User = new User
				{
					City = "requester_city",
					DateOfBirth = _now.Date,
					Email = "requester_email",
					FirstName = "requester_firstName",
					LastName = "requester_lastName",
					Gender = User.Sex.Male,
					Id = 2,
					PictureUrl = "requester_pictureUrl",
					UserName = "requester_userName"
				}
			};

			var actual = _sut.Convert(requesterUser, input);

			Assert.AreEqual(expected, actual);
		}
	}
}
