using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
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
        private const string CreateTable = "create table posts (id bigint identity(1,1) primary key," + "text nvarchar(160) null," + "item_id nvarchar(10) not null," + "user_id bigint not null," + "timestamp DATETIME not null default(getdate())," + "photo_url nvarchar(128) not null)";

        [SetUp]
        public void SetUp()
        {
            _mapper = null;
            _connection = DbUtils.CreateConnection("TestDbPostRepository.sdf",CreateTable);
           _sut = new PostRepository(_connection,_mapper);
        }



        [Test]
        public void TestReadDbPost()
        {
           /* var dbPost = new DbPost { ItemId = "188", Text = "post", PhotoUrl = "urlPhoto", UserId = 1};
            var id = _sut.Save(dbPost);
            var loaded = _sut.Read(id);
            Assert.AreEqual(dbPost.ItemId, loaded.ItemId);
            Assert.AreEqual(dbPost.Text, loaded.Text);
            Assert.AreEqual(dbPost.PhotoUrl, loaded.PhotoUrl);
            Assert.AreEqual(dbPost.UserId, loaded.UserId);*/

        }

       
    }
}
