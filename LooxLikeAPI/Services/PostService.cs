using LooxLikeAPI.Mapper;
using LooxLikeAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Services
{
    public class PostService : IPostService
    {
        private IPostMapper postMapper;
        private IPostRepository postRepository;


        public PostService(IPostRepository postRepository, IPostMapper postMapper)
        {
            this.postRepository = postRepository;
            this.postMapper = postMapper;
        }


        public Response.PostResponse getPostResponse(long id)
        {
            return postMapper.convert(postRepository.read(id));
        }
    }
}