using System;
using System.Collections.Generic;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using NUnit.Framework;

namespace LooxLikeAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly dynamic _connection;
        private readonly IPostMapper _mapper;

        public PostRepository(dynamic connection, IPostMapper mapper)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public Post Read(long id)
        {
	        var usersTable = _connection.users;
	        var likesTable = _connection.likes;
	        var postsTable = _connection.posts;




			var dbPost = (DbPost) postsTable.FindById(id);
			var dbUser = (DbUser) usersTable.FindById(dbPost.UserId);
			/*var dbLikeUserList = 
				(List<DbUser>)likesTable.FindByPostId(id)
				.Join(usersTable).On(usersTable.UserId == likesTable.userId);*/
	        var dbLikes = (HashSet<DbLike>)likesTable.FindAllByPostId(dbPost.Id);
			var dbLikeUserSet = new HashSet<DbUser>();
			foreach (var like in dbLikes)
			{
				dbLikeUserSet.Add((DbUser)usersTable.FindById(like.UserId));
			}
			var result = _mapper.Convert(dbPost, dbUser, dbLikeUserSet);
            return result;
        }

        public long Save(Post post)
        {
            var dbPost = _mapper.Convert(post);
            var result = _connection.posts.Insert(item_id: dbPost.ItemId, text: dbPost.Text, user_id: dbPost.UserId, photo_url: dbPost.PhotoUrl);
            return result;
        }


        public IList<Post> GetDbPostsByPage(int page)
        {
            // TODO paginazione
            var postList = _connection.posts.FindAll();
            var result = new List<Post>();

            foreach (DbPost dbPost in postList)
            {
                var dbUser = (DbUser)_connection.users.FindById(dbPost.UserId);
               // result.Add(_mapper.Convert(dbPost,dbUser));
            }
            return result;
        }

        public IList<Post> GetDbPostsByPage(int page, string sex)
        {
            throw new System.NotImplementedException();
        }
    }
}