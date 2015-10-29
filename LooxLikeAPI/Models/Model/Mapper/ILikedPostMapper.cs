using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Models.Model.Mapper
{
	public interface ILikedPostMapper
	{
		DbLike Convert(LikedUserPost likedUserPost);
		LikedUserPost Convert(DbUser creatorPostDbUser, DbUser likedPostDbUser, 
			DbPost post, IEnumerable<DbUser> dbLikeUsers,
			DbLike dbLike);
	}
}
