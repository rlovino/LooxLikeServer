using LooxLikeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Models.JSONModel.Response;
using System.Net.Http;
using System.Text;
using System.Web.Http.ModelBinding;
using LooxLikeAPI.Models.JSONModel.Request;
using Newtonsoft.Json;
using LooxLikeAPI.Models.Model.Mapper;

namespace LooxLikeAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IResponseRequestPostMapper _responseRequestPostMapper;
	    private readonly IPhotoUploaderService _uploaderService;
	    private readonly IUserService _userService;
	    private readonly LikedPostMapper _likedPostMapper;
	    private readonly LikedPostService _likedPostService;

	    public PostController(IPostService postService, IResponseRequestPostMapper responseRequestPostMapper, IPhotoUploaderService uploaderService, IUserService userService, LikedPostMapper likedPostMapper, LikedPostService likedPostService)
        {
	        _uploaderService = uploaderService;
	        _postService = postService;
	        _responseRequestPostMapper = responseRequestPostMapper;
		    _userService = userService;
		    _likedPostMapper = likedPostMapper;
		    _likedPostService = likedPostService;
        }

	    [Route("post/likedpost")]
	    [HttpPost]
	    public HttpResponseMessage SetLike([FromBody] LikedPostRequest request)
	    {
		    var post = _postService.GetPost(request.PostId);
		    var user = _userService.GetUser(request.Username);
		    var likedPost = _likedPostMapper.Convert(user, post);
		    var result = _likedPostService.Save(likedPost);
		    var httpMessageResponse = Request.CreateResponse(HttpStatusCode.Created, result);
		    return httpMessageResponse;
	    }


		[Route("post")]
        [HttpPost]
	    public HttpResponseMessage SavePost([ModelBinder(typeof(PostRequestBinder))] PostRequest request)
		{
			if (request == null)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
		    string username = RequestContext.Principal.Identity.Name;
			var url = _uploaderService.UploadPhoto(request, username);
			var user = _userService.GetUser(username);
			var post = _responseRequestPostMapper.Convert(request, url, user);
			var createdPost = _postService.Save(post);
			var jsonPostResponse = _responseRequestPostMapper.Convert(createdPost,username);
			HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonPostResponse);
			return httpResponseMessage;

	    }

	    public HttpResponseMessage Get(long id)
	    {
		    string username = RequestContext.Principal.Identity.Name;
            JsonPostResponse jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPost(id), username);
			HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResponse);
			

            return httpResponseMessage;
        }

        [Route("post/page/{page:int}")]
		public HttpResponseMessage GetAllPostByPage(int page, string gender = "")
        {
            
            string username = RequestContext.Principal.Identity.Name;
	        if (gender == "")
	        {
		        List<JsonPostResponse> jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPostAtPage(page),username);
				HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResponse);
		        
				return httpResponseMessage;
	        }

	        else
	        {
				List<JsonPostResponse> jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPostAtPage(page, Utils.Sex(gender)),username);
				HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK,jsonResponse);

				return httpResponseMessage;
	        }
        }


    }
}