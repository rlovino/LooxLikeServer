using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly dynamic _connection;
        private readonly IUserMapper _mapper;

        public UserRepository(dynamic connection,IUserMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public User Read(long id)
        {
            DbUser dbUser = (DbUser)_connection.users.FindById(id);
            return _mapper.Convert(dbUser);

        }

	    public User Read(string username)
	    {
			DbUser dbUser = (DbUser)_connection.users.FindAllByUsername(username).FirstOrDefault();
			return _mapper.Convert(dbUser);
		}

	    public long Save(User user)
        {
            var dbUser = _mapper.Convert(user);

            var result = _connection.users.Insert(user_name: dbUser.UserName, first_name: dbUser.FirstName,
                last_name: dbUser.LastName, sex: dbUser.Sex,
                email: dbUser.Email, date_of_birth: dbUser.DateOfBirth,
                city: dbUser.City, picture_url: dbUser.PictureUrl);
            return result.id;
        }
    }
}