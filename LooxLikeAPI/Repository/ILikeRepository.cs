using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Repository
{
	public interface ILikeRepository
	{
		Tuple<long,long> Save(LikedUserPost likedPost);
		LikedUserPost Read(Tuple<long,long> key);
	}
}
