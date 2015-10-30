using System.Collections.Generic;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Repository
{
    public interface IPostRepository
    {
        Post Read(long id);
        long Save(Post post);
        IList<Post> GetDbPostsByPage(int page);
        IList<Post> GetDbPostsByPage(int page, string sex);

	    IList<Post> GetLikedDbPosts(int page, long userId);
    }
}
