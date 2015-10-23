using LooxLikeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
	    private IResponseJsonPostMapper _postResponseJsonPostMapper;

        public PostController(IPostService postService, IResponseJsonPostMapper postResponseJsonPostMapper)
        {
	        _postService = postService;
	        _postResponseJsonPostMapper = postResponseJsonPostMapper;
        }

	    public JsonPostResponse Get(long id)
	    {
		    string username = RequestContext.Principal.Identity.Name;

            return _postResponseJsonPostMapper.Convert(_postService.GetPost(id),username);
        }


    }
}