using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MappersTest
{
    [TestFixture]
    class PostMapperTest
    {

        private IPostMapper _sut;

        [SetUp]
        public void setUp()
        {
            _sut = new PostMapper();
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
                UserId = 3
            };

            var expectedResult = new Post
            {
                User = new User(),
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
