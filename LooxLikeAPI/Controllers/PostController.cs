using LooxLikeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public Post Get(long id)
        {
            return _postService.GetPost(id);

        }


    }
}