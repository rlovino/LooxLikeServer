using System;
using System.Collections.Generic;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LooxLikeAPI.Tests.RepositoriesTest
{
    [TestFixture]
    public class PostRepositoryTest
    {
        private IPostRepository _sut;
        private IPostMapper _mapper;
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
		private const string CreateTablePosts =
			"create table posts " +
			"(id bigint identity(1,1) primary key," +
			"text nvarchar(160) null," +
			"item_id nvarchar(10) not null," +
			"user_id bigint not null," +
			"timestamp DATETIME not null default(getdate())," +
			"photo_url nvarchar(128) not null) ";
	    private const string InsertPost = 
			"insert into posts " +
			"(text, item_id, user_id, photo_url) " +
			"values ('text','itemId',1,'photoUrl') ";

	    private const string InsertUser =
			"insert into users " +
			"(user_name, first_name, last_name, sex, email, date_of_birth, city, picture_url)" +
            "values ('userName','firstName','lastName','m','user@gmail.com','1990-01-01','city','pictureUrl') ";
        [SetUp]
        public void SetUp()
        {
            _mapper = new PostMapper();
            var tables = new List<string>{CreateTableUsers, CreateTablePosts};
            var inserts = new List<string> { InsertUser,InsertPost };
            _connection = DbUtils.CreateConnection("TestDbPostRepository.sdf", tables, inserts);
           _sut = new PostRepository(_connection,_mapper);
        }




	    [Test]
        public void TestReadDbPost()
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
		    var expectedPost = new Post
		    {
			    Id = 1,
			    ItemId = "itemId",
			    PhotoUrl = "photoUrl",
			    Text = "text",
			    TimeStamp = DateTime.Now,
			    User = user
		    };

		    const int postId = 1;
		    var actual = _sut.Read(postId);
			Assert.AreEqual(expectedPost.ItemId, actual.ItemId);
			Assert.AreEqual(expectedPost.Text, actual.Text);
			Assert.AreEqual(expectedPost.PhotoUrl, actual.PhotoUrl);

        }

       
    }
}
