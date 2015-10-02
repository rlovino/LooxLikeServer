using System.Collections.Generic;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Repository
{
    public interface IPostRepository
    {
        DbPost read(long id);
        long save(DbPost post);
        IList<DbPost> GetDbPostsByPage(int page);
        IList<DbPost> GetDbPostsByPage(int page, string sex);
        
    }
}
