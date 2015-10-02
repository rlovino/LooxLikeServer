using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
        Post convert(DbPost post);
    }
}