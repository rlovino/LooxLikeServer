//using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
//using LooxLikeAPI.Mapper;
//using LooxLikeAPI.Models.DBModel;
//using LooxLikeAPI.Models.Model;
//using LooxLikeAPI.Repository;
//using LooxLikeAPI.Services;
//using Moq;
//using NUnit.Framework;

//namespace LooxLikeAPI.Tests.ServicesTest
//{
//    [TestFixture]
//    internal class PostServiceTest
//    {
//        private IPostService _sut;
//        private IPostRepository _postRepository;

//        [SetUp]
//        public void SetUp()
//        {
//            var postRepositoryMock = new Mock<IPostRepository>();
//            var postMapperMock = new Mock<IPostMapper>();

//            postMapperMock.Setup(it => it.convert(It.IsAny<DbPost>())).Returns(new Post());

//            IList<DbPost> postList = new List<DbPost>
//            {
//                new DbPost(),
//                new DbPost()
                
//            };
//            postRepositoryMock.Setup(it => it.GetDbPostsByPage(1)).Returns(postList);


//            _sut = new PostService(postRepositoryMock.Object, postMapperMock.Object);
//        }


        

    
//    }
//}
