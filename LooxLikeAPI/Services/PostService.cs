using LooxLikeAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
    public class PostService : IPostService
    {
        
        private readonly IPostRepository _postRepository;


        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IList<Post> GetPostAtPage(int page)
        {
            return _postRepository.GetDbPostsByPage(page);
           
        }

        public IList<Post> GetPostAtPage(int page, User.Sex sex)
        {
            return _postRepository.GetDbPostsByPage(page).Where(post => post.User.Gender == sex).ToList();

        }

        public Post GetPost(long id)
        {
            return _postRepository.Read(id);
        }
       
    }
}