using LooxLikeAPI.Response;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
        PostResponse convert(DbPost post);
     //   public Post convert(PostRequest postRequest); TO DO


    }
}