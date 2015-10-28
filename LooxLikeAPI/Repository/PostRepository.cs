using System;
using System.Collections.Generic;
using System.Linq;
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
	        var dbLikes = (HashSet<DbLike>)likesTable.FindAllByPostId(dbPost.Id);
			var dbLikeUserSet = GetDbLikeUserSet(dbLikes, usersTable);
	        var result = _mapper.Convert(dbPost, dbUser, dbLikeUserSet);
            return result;
        }

	    private HashSet<DbUser> GetDbLikeUserSet(HashSet<DbLike> dbLikes, dynamic usersTable)
	    {
		    var dbLikeUserSet = new HashSet<DbUser>();
		    foreach (var like in dbLikes)
		    {
			    dbLikeUserSet.Add((DbUser) usersTable.FindById(like.UserId));
		    }
		    return dbLikeUserSet;
	    }

	    public long Save(Post post)
        {
            var dbPost = _mapper.Convert(post);
            var result = (DbPost)_connection.posts.Insert(item_id: dbPost.ItemId, text: dbPost.Text, user_id: dbPost.UserId, photo_url: dbPost.PhotoUrl);
		    return result.Id;
        }


        public IList<Post> GetDbPostsByPage(int page)
        {
            var postList = (List<DbPost>)_connection.posts.All();

	        return (from dbPost in postList 
					let dbUser = (DbUser) _connection.users.FindById(dbPost.UserId) 
					let dbLikes = (HashSet<DbLike>) _connection.likes.FindAllByPostId(dbPost.Id) 
					let dbLikeUserSet = GetDbLikeUserSet(dbLikes, _connection.users) 
					select _mapper.Convert(dbPost, dbUser, dbLikeUserSet)).Cast<Post>().ToList();
        }

        public IList<Post> GetDbPostsByPage(int page, string sex)
        {
			var userList = (List<DbUser>) _connection.users.FindAllBySex(sex);

			return (from dbUser in userList
					let dbPosts = (List<DbPost>)_connection.posts.FindAllByUserId(dbUser.Id)
					from dbPost in dbPosts
					let dbLikes = (HashSet<DbLike>)_connection.likes.FindAllByPostId(dbPost.Id)
					let dbLikeUserSet = GetDbLikeUserSet(dbLikes, _connection.users)
					select _mapper.Convert(dbPost, dbUser, dbLikeUserSet)).Cast<Post>().ToList(); 
        }
    }
}