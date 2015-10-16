using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public interface IResponseJsonPostMapper
	{
		JsonPostResponse Convert(Post post, string username);
	}
}
