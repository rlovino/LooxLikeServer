using System;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Response;
using NUnit.Framework;

namespace LooxLikeAPI.Tests.MappersTest
{
	[TestFixture]
	class PostResponseMapperTest
	{
		private IPostResponseMapper _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = null;
		}

		[Test]
		public void TestConvertPost()
		{
			var creationDateTime = DateTime.Now;
			var user = new User{UserName = "userName"};
			var requesterUsername = "requesterUsername";
			
			var input = new Post { Id = 0, ItemId = "itemId", PhotoUrl = "photoUrl", Text = "description", TimeStamp = creationDateTime, User = user};
			
			var expectedResult = new PostResponse { IdPost = 0, 
				CreationDateTime = creationDateTime,
				Description = "Description",
				Liked = true,
				LikeNumber = 1,
				PhotoUrl = "photoUrl",
				UserName = "userName",
				ItemId = "itemId"
			};

			var output = _sut.Convert(input, requesterUsername);
			Assert.AreEqual(expectedResult,output);
		}

		

	}
}
