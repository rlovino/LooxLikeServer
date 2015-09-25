using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private dynamic _connection;

        public UserRepository(dynamic connection)
        {
            _connection = connection;
        }

        public DbUser read(long id)
        {
            return (DbUser)_connection.users.FindById(id);
        }

        public long save(DbUser dbUser)
        {
            var result = _connection.users.Insert(user_name: dbUser.UserName, first_name: dbUser.FirstName,
                last_name: dbUser.LastName, sex: dbUser.Sex,
                email: dbUser.Email, date_of_birth: dbUser.DateOfBirth,
                city: dbUser.City, picture_url: dbUser.PictureUrl);
            return result.id;
        }
    }
}