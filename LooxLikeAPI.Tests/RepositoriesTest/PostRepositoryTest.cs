using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Repository;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LooxLikeAPI.Tests.MapperTests
{
    [TestFixture]
    public class PostRepositoryTest
    {
        private IPostRepository _sut;
        private dynamic connection;
        private readonly string createTable = "create table posts (id bigint identity(1,1) primary key,"+
            "text nvarchar(160) null,"+
            "item_id nvarchar(10) not null,"+
            "user_id bigint not null,"+
            "timestamp DATETIME not null default(getdate()),"+
            "photo_url nvarchar(128) not null)";

        [SetUp]
        public void setUp()
        {
            connection = DbUtils.createConnection("TestDbPostRepository.sdf",createTable);
           _sut = new PostRepository(connection);
        }



        [Test]
        public void TestReadDbPost()
        {
            var dbPost = new DbPost { ItemId = "188", Text = "post", PhotoUrl = "urlPhoto", UserId = 1};
            var id = _sut.save(dbPost);
            var loaded = _sut.read(id);
            Assert.AreEqual(dbPost.ItemId, loaded.ItemId);
            Assert.AreEqual(dbPost.Text, loaded.Text);
            Assert.AreEqual(dbPost.PhotoUrl, loaded.PhotoUrl);
            Assert.AreEqual(dbPost.UserId, loaded.UserId);

        }

       
    }
}
