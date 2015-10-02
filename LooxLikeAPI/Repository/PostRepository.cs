using System.Collections.Generic;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Repository
{
    public class PostRepository : IPostRepository
    {

        private dynamic _connection;

        public PostRepository(dynamic connection)
        {
            this._connection = connection;
        }

        public DbPost read(long id)
        {
            return (DbPost)_connection.posts.FindById(id);
        }

        public long save(DbPost dbPost)
        {
            var result = _connection.posts.Insert(item_id: dbPost.ItemId, text: dbPost.Text, user_id: dbPost.UserId, photo_url: dbPost.PhotoUrl);
            return result.id;
        }

        public IList<DbPost> GetDbPostsByPage(int page)
        {
            throw new System.NotImplementedException();
        }

        public IList<DbPost> GetDbPostsByPage(int page, string sex)
        {
            throw new System.NotImplementedException();
        }
    }
}