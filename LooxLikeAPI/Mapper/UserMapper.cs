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

        public DbUser Convert(User user)
        {
            var sex = "m";
            if (User.Sex.Female == user.Gender)
                sex = "f";
            else if (User.Sex.NoGender == user.Gender)
                sex = "n";

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