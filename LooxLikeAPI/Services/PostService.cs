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
	        return _postRepository.GetDbPostsByPage(page, Utils.Sex(sex));

        }

        public Post GetPost(long id)
        {
            return _postRepository.Read(id);
        }

	    public Post Save(Post post)
	    {
		    return _postRepository.Read(_postRepository.Save(post));
	    }
    }
}