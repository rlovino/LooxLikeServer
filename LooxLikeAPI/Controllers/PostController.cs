using LooxLikeAPI.Response;
using LooxLikeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LooxLikeAPI.Controllers
{
    public class PostController : ApiController
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public PostResponse get(long id)
        {
            return _postService.getPostResponse(id);

        }


    }
}