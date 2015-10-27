using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {
	    private IUserMapper _userMapper;

	    public PostMapper(IUserMapper userMapper)
	    {
			_userMapper = userMapper;
	    }

		public Post Convert(DbPost dbPost, DbUser dbUser, IEnumerable<DbUser> dbLikeUsers)
		{

			var user = _userMapper.Convert(dbUser);
			var likeUsers = _userMapper.Convert(dbLikeUsers);
            return new Post
            {
                Id = dbPost.Id,
                ItemId = dbPost.ItemId,
                PhotoUrl = dbPost.PhotoUrl,
                Text = dbPost.Text,
                TimeStamp = dbPost.Timestamp,
                User = user,
				LikeUserEnumerable = likeUsers
            };
        }

	    


	    public DbPost Convert(Post post)
        {
            return new DbPost
            {
                ItemId = post.ItemId,
                PhotoUrl = post.PhotoUrl,
                Text = post.Text,
                Timestamp = post.TimeStamp,
                UserId = post.User.Id
            };
        }
    }
}