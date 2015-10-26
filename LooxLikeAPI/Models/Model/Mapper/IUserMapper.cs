using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public interface IUserMapper
    {
        User Convert(DbUser dbUser);
	    HashSet<User> Convert(IEnumerable<DbUser> dbUsers); 
		DbUser Convert(User user);
    }
}