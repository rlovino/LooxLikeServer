using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models;
using LooxLikeAPI.Response;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MapperTests
{
    [TestFixture]
    class PostMapperTest
    {

        private IPostMapper _sut;
        private Post _input;

        [SetUp]
        public void Init()
        {
            _sut = new PostMapper();
            _input = new Post{Id = 0, Message = "message_test"};
        }

        [Test]
        public void IdPostResponseEqualsToIdPost()
        {
            var expectedResult = new PostResponse{Id = 0,Message = "message_test"};
            var response = _sut.convert(_input);
            Assert.Equals(expectedResult, response);
        }


    }
}
