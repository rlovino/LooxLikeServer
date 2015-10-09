using System;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {
        public Post Convert(DbPost dbPost, DbUser dbUser)
        {
            User.Sex sex = User.Sex.Male;
            var stringSex = dbUser.Sex;
            if(stringSex.Equals("f"))
                sex = User.Sex.Female;
            else if (stringSex.Equals("n"))
                sex = User.Sex.NoGender;

            User user = new User
            {
                Id = dbUser.Id,
                City = dbUser.City,
                DateOfBirth = dbUser.DateOfBirth,
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                Gender = sex,
                LastName = dbUser.LastName,
                PictureUrl = dbUser.PictureUrl,
                UserName = dbUser.UserName
            };

            return new Post
            {
                Id = dbPost.Id,
                ItemId = dbPost.ItemId,
                PhotoUrl = dbPost.PhotoUrl,
                Text = dbPost.Text,
                TimeStamp = dbPost.Timestamp,
                User = user
            };
        }

        public DbPost Convert(Post post)
        {
            return new DbPost
            {
                Id = post.Id,
                ItemId = post.ItemId,
                PhotoUrl = post.PhotoUrl,
                Text = post.Text,
                Timestamp = post.TimeStamp,
                UserId = post.User.Id
            };
        }
    }
}