using LooxLikeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Models;
using System.Net.Http;
using System.Text;

namespace LooxLikeAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IResponseJsonPostMapper _postResponseJsonPostMapper;
        private readonly JsonSerializer _jsonSerializer;

        public PostController(IPostService postService, IResponseJsonPostMapper postResponseJsonPostMapper, JsonSerializer serializer)
        {
	        _postService = postService;
	        _postResponseJsonPostMapper = postResponseJsonPostMapper;
            _jsonSerializer = serializer;
        }

	    public HttpResponseMessage Get(long id)
	    {
		    string username = RequestContext.Principal.Identity.Name;

            JsonPostResponse jsonResponse = _postResponseJsonPostMapper.Convert(_postService.GetPost(id), username);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(_jsonSerializer.Serialize(jsonResponse), Encoding.Unicode);

            return httpResponseMessage;
        }

        [Route("post/page/{page:int}")]
		public HttpResponseMessage GetAllPostByPage(int page, string gender = "")
        {
            
            string username = RequestContext.Principal.Identity.Name;
	        if (gender == "")
	        {
		        List<JsonPostResponse> jsonResponse = _postResponseJsonPostMapper.Convert(_postService.GetPostAtPage(page),
			        username);

		        HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK);
		        httpResponseMessage.Content = new StringContent(_jsonSerializer.Serialize(jsonResponse), Encoding.Unicode);

		        return httpResponseMessage;
	        }

	        else
	        {
				List<JsonPostResponse> jsonResponse = _postResponseJsonPostMapper.Convert(_postService.GetPostAtPage(page, Utils.Sex(gender)),
				   username);
				HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK);
				httpResponseMessage.Content = new StringContent(_jsonSerializer.Serialize(jsonResponse), Encoding.Unicode);

				return httpResponseMessage;
	        }
        }


    }
}