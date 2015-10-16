using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public class ResponseJsonPostMapper : IResponseJsonPostMapper
	{
		public JsonPostResponse Convert(Post post, string username)
		{
			return new JsonPostResponse
			{
				C10 = post.ItemId,
				CreationTime = post.TimeStamp,
				Description = post.Text,
				Liked = post.LikeUserEnumerable.Any(user => user.UserName == username),
				NumLikes = post.LikeUserEnumerable.Count,
				PhotoUrl = post.PhotoUrl,
				PostId = post.Id,
				UserName = post.User.UserName
			};
		}
	}
}