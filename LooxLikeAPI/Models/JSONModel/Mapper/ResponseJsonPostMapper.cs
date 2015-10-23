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

        public List<JsonPostResponse> Convert(IList<Post> posts, string username)
        {

            var list = posts.SelectMany(post => new List<JsonPostResponse>{
                Convert(post, username)
            });

            return list.ToList<JsonPostResponse>();
            //List<JsonPostResponse> convertedPosts = new List<JsonPostResponse>();
            //foreach (Post post in posts)
            //{
            //    convertedPosts.Add(Convert(post, username));
            //}
            //return convertedPosts;
        }
	}
}