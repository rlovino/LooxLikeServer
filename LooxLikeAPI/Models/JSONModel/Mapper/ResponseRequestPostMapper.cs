using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.JSONModel.Request;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public class ResponseRequestPostMapper : IResponseRequestPostMapper
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
        }

		public Post Convert(PostRequest request, string photoUrl, User user)
		{
			return new Post
			{
				ItemId = request.C10,
				LikeUserEnumerable = new HashSet<User>(),
				PhotoUrl = photoUrl,
				Text = request.Description,
				TimeStamp = DateTime.Now,
				User = user
			};
		}
	}
}