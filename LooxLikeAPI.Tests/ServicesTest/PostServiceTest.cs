using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Repository;
using LooxLikeAPI.Services;
using Moq;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.ServicesTest
{
    [TestFixture]
    class PostServiceTest
    {
        private IPostService _sut;
        private IPostRepository _postRepository;

        [SetUp]
        public void SetUp()
        {/*
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(it => it.read(UserId)).Returns(fakeUser);


            _sut = new PostMapper(userRepositoryMock.Object, new UserMapper());*/
            _sut = new PostService();
        }
    }
}
