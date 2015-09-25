using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Repository
{
    public interface IPostRepository
    {
        DbPost read(long id);
        long save(DbPost post);
    }
}
