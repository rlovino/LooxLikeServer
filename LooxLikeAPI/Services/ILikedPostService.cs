using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
	public interface ILikedPostService
	{
		LikedUserPost Save(LikedUserPost likedPost);
	}
}
