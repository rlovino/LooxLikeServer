using System.Collections.Generic;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
		Post Convert(DbPost dbPost, DbUser dbUser, IEnumerable<DbUser> dbLikeUserList);
        DbPost Convert(Post post);  
    }
}