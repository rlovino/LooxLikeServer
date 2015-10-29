using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Models.JSONModel.Mapper
{
	public interface IResponseRequestLikePostMapper
	{
		LikedUserPost Convert(User user, Post post);
		JsonLikeResponse Convert(LikedUserPost likedUserPost);

	}
}
