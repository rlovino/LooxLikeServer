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
    class UserMapperTest
    {
        private IUserMapper _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UserMapper();
        }

        [Test]
        public void TestConvertDbUserToUser()
        {
            var Id = 1;
            var UserName = "user01";
            var FirstName = "FirstName";
            var LastName = "LastName";
            var Sex = "m";
            var Email = "user@email";
            var City = "Bologna";
            var DateOfBirth = DateTime.Now;
            var PictureUrl = "picture01";

            var input = new DbUser
            {
                Id = Id,
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Sex = Sex,
                Email = Email,
                City = City,
                DateOfBirth = DateOfBirth,
                PictureUrl = PictureUrl
            };

            var expected = new User
            {
                Id = Id,
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Gender = User.Sex.Male,
                Email = Email,
                City = City,
                DateOfBirth = DateOfBirth,
                PictureUrl = PictureUrl
            };

            var actual = _sut.convert(input);

            Assert.AreEqual(expected, actual);

          
        }
    }
}
