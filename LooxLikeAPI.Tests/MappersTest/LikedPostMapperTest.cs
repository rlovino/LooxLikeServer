﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
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
		private IPostMapper _postMapper;
		private IUserMapper _userMapper;
		private readonly DateTime _now = DateTime.Now;

		[SetUp]
		public void SetUp()
		{
			_userMapper = new UserMapper();
			_postMapper = new PostMapper(_userMapper);
			_sut = new LikedPostMapper(_postMapper, _userMapper);
		}

		//DbLike Convert(LikedUserPost likedUserPost)
		[Test]
		public void TestConvertLikedUserPostToDbLike()
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

			var input = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = post,
				User = newLikeUser
			};


			var expected = new DbLike
			{
				CreationTime = _now,
				PostId = 1,
				UserId = 4
			};

			var actual = _sut.Convert(input);

			Assert.AreEqual(expected, actual);
		}


		[Test]
		public void TestConvertDbEntriesToLikedUserPost()
		{

			DbUser creatorPostDbUser = new DbUser
			{
				UserName = "creator_userName",
				City = "creator_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "creator_email",
				FirstName = "creator_firstName",
				Id = 1,
				LastName = "creator_lastName",
				PictureUrl = "creator_pictureUrl",
				Sex = "m"
			};
			DbUser likedPostDbUser = new DbUser
			{
				UserName = "like_userName",
				City = "like_city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "like_email",
				FirstName = "like_firstName",
				Id = 2,
				LastName = "like_lastName",
				PictureUrl = "like_pictureUrl",
				Sex = "m"
			};
			DbPost post = new DbPost
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				Timestamp = _now,
				UserId = 1
			};
			IEnumerable<DbUser> dbLikeUsers = new HashSet<DbUser>
			{
				new DbUser
				{
					UserName = "userName1",
					City = "city1",
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "email1",
					FirstName = "firstName1",
					Id = 3,
					LastName = "lastName1",
					PictureUrl = "pictureUrl1",
					Sex = "m"
				},
				new DbUser
				{
					UserName = "userName2",
					City = "city2",
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "email2",
					FirstName = "firstName2",
					Id = 4,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					Sex = "m"					
				}
			};
			DbLike dbLike = new DbLike
			{
				CreationTime = _now,
				PostId = 1,
				UserId = 2
			};

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
					Id = 3,
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
					Id = 4,
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
				Id = 2,
				LastName = "like_lastName",
				PictureUrl = "like_pictureUrl",
				UserName = "like_userName"
			};

			Post postToLike = new Post
			{
				Id = 1,
				ItemId = "itemId",
				PhotoUrl = "photoUrl",
				Text = "text",
				TimeStamp = _now,
				User = creatorUser,
				LikeUserEnumerable = likeUsers
			};

			var expected = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = postToLike,
				User = newLikeUser
			};

			var actual = _sut.Convert(creatorPostDbUser, likedPostDbUser, post, dbLikeUsers, dbLike);

			Assert.AreEqual(expected, actual);
		}
	}
}
