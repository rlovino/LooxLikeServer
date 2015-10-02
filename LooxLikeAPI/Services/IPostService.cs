using System.Collections.Generic;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
    public interface IPostService
    {
        IList<Post> GetPostAtPage(int page);
        IList<Post> GetPostAtPage(int page, User.Sex sex);
    }

}
