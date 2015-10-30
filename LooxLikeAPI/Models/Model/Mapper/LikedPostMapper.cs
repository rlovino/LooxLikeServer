using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Models.Model.Mapper
{
	public class LikedPostMapper: ILikedPostMapper
	{
		private readonly IPostMapper _postMapper;
		private readonly IUserMapper _userMapper;

		public LikedPostMapper(IPostMapper postMapper, IUserMapper userMapper)
		{
			_postMapper = postMapper;
			_userMapper = userMapper;
		}


		public DbLike Convert(LikedUserPost likedUserPost)
		{
			return new DbLike
			{
				PostId = likedUserPost.Post.Id,
				UserId = likedUserPost.User.Id,
				CreationTime = likedUserPost.CreationDateTime
			};
		}

		public LikedUserPost Convert(DbUser creatorPostDbUser, DbUser likedPostDbUser, DbPost post, IEnumerable<DbUser> dbLikeUsers, DbLike dbLike )
		{
			return new LikedUserPost
			{
				Post = _postMapper.Convert(post, creatorPostDbUser, dbLikeUsers),
				User = _userMapper.Convert(likedPostDbUser),
				CreationDateTime = dbLike.CreationTime
			};
		}

	}
}