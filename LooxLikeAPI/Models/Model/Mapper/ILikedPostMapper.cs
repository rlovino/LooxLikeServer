using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooxLikeAPI.Models.Model.Mapper
{
	public interface ILikedPostMapper
	{
		LikedUserPost Convert(User user, Post post);
	}
}
