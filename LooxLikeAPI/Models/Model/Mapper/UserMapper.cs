using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public class UserMapper: IUserMapper
    {

		

        public User Convert(DbUser user)
        {
            return new User
            {
                Id = user.Id,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = Utils.Sex(user.Sex),
                LastName = user.LastName,
                PictureUrl = user.PictureUrl,
                UserName = user.UserName
            };

        }

	    public HashSet<User> Convert(IEnumerable<DbUser> dbUsers)
	    {
			var users = new HashSet<User>();

			foreach (var entry in dbUsers)
			{
				users.Add(new User
				{
					Id = entry.Id,
					City = entry.City,
					DateOfBirth = entry.DateOfBirth,
					Email = entry.Email,
					FirstName = entry.FirstName,
					Gender = Utils.Sex(entry.Sex),
					LastName = entry.LastName,
					PictureUrl = entry.PictureUrl,
					UserName = entry.UserName
				});
			}
		    return users;
	    }

	    public DbUser Convert(User user)
	    {
		    var sex = Utils.Sex(user.Gender);

		    return new DbUser
            {
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PictureUrl = user.PictureUrl,
                Sex = sex,
                UserName = user.UserName
            };
	    }

		

	    
    }
}