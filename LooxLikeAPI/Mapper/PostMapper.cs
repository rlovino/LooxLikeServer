using System;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {
        private IUserRepository _userRepository;

        public PostMapper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Post convert(DbPost post)
        {
            return new Post
            {
                Id = post.Id,
                ItemId = post.ItemId,
                PhotoUrl = post.PhotoUrl,
                Text = post.Text,
                TimeStamp = post.Timestamp,
 //TODO               User = _userRepository.read(post.UserId);
            };
        }
    }
}