using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;
using System.Collections.Generic;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public interface IResponseJsonPostMapper
	{
		JsonPostResponse Convert(Post post, string username);
        List<JsonPostResponse> Convert(IList<Post> posts, string username);

	}
}
