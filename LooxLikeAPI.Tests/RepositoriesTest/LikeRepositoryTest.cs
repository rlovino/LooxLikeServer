using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Models.Model.Mapper;
using LooxLikeAPI.Repository;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
	[TestFixture]
	class LikeRepositoryTest
	{
		private dynamic _connection;
		private ILikedPostMapper _likedPostMapper;
		private IPostMapper _postMapper;
		private IUserMapper _userMapper;
		private ILikeRepository _sut;
		private readonly DateTime _now = DateTime.Now;

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
		private const string CreateTablePosts =
			"create table posts " +
			"(id bigint identity(1,1) primary key," +
			"text nvarchar(160) null," +
			"item_id nvarchar(10) not null," +
			"user_id bigint not null," +
			"timestamp DATETIME not null default(getdate())," +
			"photo_url nvarchar(128) not null) ";

		private const string CreateTableLikes =
			"create table likes " +
			"(post_id bigint not null," +
			"user_id bigint not null," +
			"creation_time datetime not null default(getdate()))";

		private const string InsertPost =
			"insert into posts " +
			"(text, item_id, user_id, photo_url) " +
			"values ('text','itemId',1,'photoUrl') ";

		private const string InsertMainUser =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
			"values ('userName','firstName','lastName','m','user@gmail.com','1990-01-01','city','pictureUrl')";
		private const string InsertLikeUser01 =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
			"values ('userName1','firstName1','lastName1','m','user1@gmail.com','1990-01-01','city1','pictureUrl1')";
		private const string InsertLikeUser02 =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
			"values ('userName2','firstName2','lastName2','m','user2@gmail.com','1990-01-01','city2','pictureUrl2')";
		private const string InsertLikeUser03 =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
			"values ('userName3','firstName3','lastName3','m','user3@gmail.com','1990-01-01','city3','pictureUrl3')";

		private const string InsertLike01 =
			 "insert into likes " +
			 "(post_id, user_id) " +
			 "values (1,2)";

		private const string InsertLike02 =
			"insert into likes " +
			"(post_id, user_id) " +
			"values (1,3)";
		private const string InsertLike03 =
			"insert into likes " +
			"(post_id, user_id) " +
			"values (1,4)";

		[SetUp]
		public void SetUp()
		{
			_userMapper = new UserMapper();
			_postMapper = new PostMapper(_userMapper);
			_likedPostMapper = new LikedPostMapper(_postMapper, _userMapper);

			var tables = new List<string>
			{
				CreateTableUsers, 
				CreateTablePosts, 
				CreateTableLikes 
			};

			var inserts = new List<string>
			{
				InsertMainUser, 
				InsertLikeUser01, 
				InsertLikeUser02, 
				InsertLikeUser03,
				InsertPost,
				InsertLike01,
				InsertLike02,
				InsertLike03
			};

			_connection = DbUtils.CreateConnection("TestDbLikeRepository.sdf", tables, inserts);
			_sut = new LikeRepository(_likedPostMapper, _connection);
		}

		//Tuple<long,long> Save(LikedUserPost likedPost);
		[Test]
		public void TestSaveLike()
		{
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
			var inputLikedPostToTest = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = postToTest,
				User = likeUserToTest
			};

			var expected = new Tuple<long, long>(1,4);
			var actual = _sut.Save(inputLikedPostToTest);

			Assert.AreEqual(expected, actual);
		}

		//LikedUserPost Read(Tuple<long, long> key);
		[Test]
		public void TestReadLike()
		{
			var input = new Tuple<long, long>(1,4);
			User likeUserToTest = new User
			{
				City = "city3",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "user3@gmail.com",
				FirstName = "firstName3",
				Gender = User.Sex.Male,
				Id = 4,
				LastName = "lastName3",
				PictureUrl = "pictureUrl3",
				UserName = "userName3"
			};
			User creatorUserToTest = new User
			{
				City = "city",
				DateOfBirth = DateTime.Parse("1990-01-01"),
				Email = "user@gmail.com",
				FirstName = "firstName",
				Gender = User.Sex.Male,
				Id = 1,
				LastName = "lastName",
				PictureUrl = "pictureUrl",
				UserName = "userName"
			};
			HashSet<User> likeUsersListToTest = new HashSet<User>
			{
				new User
				{
					City = "city1",
					DateOfBirth = DateTime.Parse("1990-01-01"),
					Email = "user1@gmail.com",
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
					Email = "user2@gmail.com",
					FirstName = "firstName2",
					Gender = User.Sex.Male,
					Id = 3,
					LastName = "lastName2",
					PictureUrl = "pictureUrl2",
					UserName = "userName2"
				},
				likeUserToTest
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
			var expected = new LikedUserPost
			{
				CreationDateTime = _now,
				Post = postToTest,
				User = likeUserToTest
			};

			var actual = _sut.Read(input);

			Assert.AreEqual(expected, actual);
		}
	}
}
