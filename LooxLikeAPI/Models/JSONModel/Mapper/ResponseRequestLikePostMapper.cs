using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public class ResponseRequestLikePostMapper : IResponseRequestLikePostMapper
	{
		public LikedUserPost Convert(User user, Post post)
		{
			return new LikedUserPost
			{
				Post = post,
				User = user,
				CreationDateTime = DateTime.Now
			};
		}		

		public JsonLikeResponse Convert(LikedUserPost likedUserPost)
		{
			return new JsonLikeResponse
			{
				likedDateTime = likedUserPost.CreationDateTime,
				likedPostId = likedUserPost.Post.Id,
				username = likedUserPost.User.UserName
			};
		}
	}
}