using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
        Post Convert(DbPost dbPost,DbUser dbUser);
        DbPost Convert(Post post);  
    }
}