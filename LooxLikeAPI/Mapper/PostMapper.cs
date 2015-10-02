using System;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {
        private IUserRepository _userRepository;
        private IUserMapper _userMapper;

        public PostMapper(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userMapper = userMapper;
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
                User = _userMapper.convert(_userRepository.read(post.UserId))
            };
        }
    }
}