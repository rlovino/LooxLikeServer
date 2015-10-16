using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Response;

namespace LooxLikeAPI.Mapper
{
	public class PostResponseMapper: IPostResponseMapper
	{
		private ILikeRepository _likeRepository;

		public PostResponse Convert(Post post, string requesterUsername)
		{
			
		}
	}
}