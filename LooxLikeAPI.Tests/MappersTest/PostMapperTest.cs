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


        [SetUp]
        public void SetUp()
        {
            _sut = new PostMapper();
           
        }


        [Test]
        public void TestConvertDbPostAndDbUserToPost()
        {
            var now = DateTime.Now;

            User user = new User
            {
                City = "city",
                DateOfBirth = now,
                Email = "email",
                FirstName = "firstName",
                Gender = User.Sex.Male,
                Id = 1,
                LastName = "lastName",
                PictureUrl = "pictureUrl",
                UserName = "userName"
            };

            Post expectedResult = new Post
            {
                Id = 1,
                ItemId = "itemId",
                PhotoUrl = "photoUrl",
                Text = "text",
                TimeStamp = now,
                User = user
            };

            var inputDbUser = new DbUser
            {
                Id = 1,
                City = "city",
                DateOfBirth = now,
                Email = "email",
                FirstName = "firstName",
                LastName = "lastName",
                PictureUrl = "pictureUrl",
                Sex = "m",
                UserName = "userName"
            };

            var inputdbPost = new DbPost
            {
                Id = 1,
                ItemId = "itemId",
                PhotoUrl = "photoUrl",
                Text = "text",
                Timestamp = now,
                UserId = 1
            };

            Assert.AreEqual(expectedResult,_sut.Convert(inputdbPost,inputDbUser));
        }

    }
}
