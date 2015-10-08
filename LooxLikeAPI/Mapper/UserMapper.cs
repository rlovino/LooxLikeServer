using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public class UserMapper: IUserMapper
    {
        public User convert(DbUser user)
        {
            var sex = User.Sex.Male;
            var stringSex = user.Sex;
            if(stringSex.Equals("f"))
                sex = User.Sex.Female;
            else if (stringSex.Equals("n"))
                sex = User.Sex.NoGender;



            return new User
            {
                Id = user.Id,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = sex,
                LastName = user.LastName,
                PictureUrl = user.PictureUrl,
                UserName = user.UserName
            };

        }
    }
}