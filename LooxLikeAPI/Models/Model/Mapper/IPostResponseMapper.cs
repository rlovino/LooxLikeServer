using System;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Response;

namespace LooxLikeAPI.Mapper
{
	public interface IPostResponseMapper
	{
		PostResponse Convert(Post post, string requesterUsername);
	}
}