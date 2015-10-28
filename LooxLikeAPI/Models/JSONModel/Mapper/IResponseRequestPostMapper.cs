using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;
using System.Collections.Generic;
using LooxLikeAPI.Models.JSONModel.Request;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public interface IResponseRequestPostMapper
	{
		JsonPostResponse Convert(Post post, string username);
        List<JsonPostResponse> Convert(IList<Post> posts, string username);
		Post Convert(PostRequest request, string photoUrl, User user);
	}
}
