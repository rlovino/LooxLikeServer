using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using LooxLikeAPI.Exceptions;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Models.Model.Mapper;
using Simple.Data.Ado;

namespace LooxLikeAPI.Repository
{
	public class LikeRepository : ILikeRepository
	{
		private readonly ILikedPostMapper _likeMapper;
		private readonly dynamic _connection;

		public LikeRepository(ILikedPostMapper mapper, dynamic connection)
		{
			_likeMapper = mapper;
			_connection = connection;
		}



		public Tuple<long,long> Save(LikedUserPost likedPost)
		{
			try
			{
				var dbLike = _likeMapper.Convert(likedPost);
				_connection.likes.Insert(post_id: dbLike.PostId, user_id: dbLike.UserId);
				return new Tuple<long, long>(dbLike.UserId, dbLike.PostId);
			}
			catch (AdoAdapterException e)
			{
				throw new SaveException(e.Message);
			}
			
		
		}

		public LikedUserPost Read(Tuple<long,long> key)
		{
			try
			{
				DbLike dbLike =(DbLike) _connection.likes.Find(_connection.likes.post_id == key.Item1 && _connection.likes.user_id == key.Item2);
				DbPost dbPost = (DbPost)_connection.posts.FindById(dbLike.PostId);
				DbUser likeDbUser = (DbUser) _connection.users.FindById(dbLike.UserId);
				DbUser creatorDbUser = (DbUser) _connection.users.FindById(dbPost.UserId);
				var dbLikes = (HashSet<DbLike>)_connection.likes.FindAllByPostId(dbPost.Id);
				var dbLikeUserSet = GetDbLikeUserSet(dbLikes, _connection.users);

				return _likeMapper.Convert(creatorDbUser, likeDbUser, dbPost, dbLikeUserSet, dbLike);

			}
			catch (AdoAdapterException e)
			{
				throw new ReadException(e.Message);
			}
			
		}

		private HashSet<DbUser> GetDbLikeUserSet(HashSet<DbLike> dbLikes, dynamic usersTable)
		{
			var dbLikeUserSet = new HashSet<DbUser>();
			foreach (var like in dbLikes)
			{
				dbLikeUserSet.Add((DbUser)usersTable.FindById(like.UserId));
			}
			return dbLikeUserSet;
		}
	}

	
}