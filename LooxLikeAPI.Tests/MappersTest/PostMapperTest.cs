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
        private const long UserId = 1;

        [SetUp]
        public void SetUp()
        {
            
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(it => it.read(UserId)).Returns(new DbUser { Id = UserId });


            _sut = new PostMapper(userRepositoryMock.Object);
        }


        [Test]
        public void TestConvertDbPostToPost()
        {
            var now = DateTime.Now;
            var input = new DbPost
            {
                Id = 1, 
                ItemId = "2",
                PhotoUrl = "photoUrl",
                Text = "text",
                Timestamp = now,
                UserId = UserId
            };

            var expectedResult = new Post
            {
                User = new User {Id=UserId},
                Id = 1,
                ItemId = "2",
                PhotoUrl = "photoUrl",
                Text = "text",
                TimeStamp = now
            };

            Assert.AreEqual(expectedResult,_sut.convert(input));
        }

    }
}
