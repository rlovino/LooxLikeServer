using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.Model.Mapper
{
	public class LikedPostMapper: ILikedPostMapper
	{
		public LikedUserPost Convert(User user, Post post)
		{
			return new LikedUserPost
			{
				Post = post,
				User = user
			};
		}
	}
}