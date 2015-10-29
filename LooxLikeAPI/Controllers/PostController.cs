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
using LooxLikeAPI.Exceptions;
using LooxLikeAPI.Models.JSONModel.Request;
using LooxLikeAPI.Models.Model;
using Newtonsoft.Json;
using LooxLikeAPI.Models.Model.Mapper;
using LooxLikeAPI.App_Start;

namespace LooxLikeAPI.Controllers
{
    [Authorize]
    [IdentityBasicAuthentication]
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IResponseRequestPostMapper _responseRequestPostMapper;
	    private readonly IPhotoUploaderService _uploaderService;
	    private readonly IUserService _userService;
	    private readonly IResponseRequestLikePostMapper _likedPostMapper;
	    private readonly ILikedPostService _likedPostService;

		public PostController(IPostService postService, IResponseRequestPostMapper responseRequestPostMapper, IPhotoUploaderService uploaderService, IUserService userService, IResponseRequestLikePostMapper likedPostMapper, ILikedPostService likedPostService)
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
	    public HttpResponseMessage SetLike( LikedPostRequest request)
	    {
		    try
		    {
				if(request.PostId < 0)
					throw new HttpResponseException(HttpStatusCode.BadRequest);


			    string username = RequestContext.Principal.Identity.Name;

			    var post = _postService.GetPost(request.PostId);
			    var user = _userService.GetUser(username);
			    var likedPost = _likedPostMapper.Convert(user, post);
			    var result = _likedPostService.Save(likedPost);
			    var jsonResponse = _likedPostMapper.Convert(result);
			    var httpMessageResponse = Request.CreateResponse(HttpStatusCode.Created, jsonResponse);
			    return httpMessageResponse;
		    }
		    catch (ReadException exception)
		    {
			    throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotFound));
		    }
		    catch (SaveException exception)
		    {
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable));
		    }
			
	    }


		[Route("post")]
        [HttpPost]
	    public HttpResponseMessage SavePost([ModelBinder(typeof(PostRequestBinder))] PostRequest request)
		{
			try
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
				var jsonPostResponse = _responseRequestPostMapper.Convert(createdPost, username);
				HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonPostResponse);
				return httpResponseMessage;
			}
			catch (ReadException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotFound));
			}
			catch (SaveException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable));
			}

				

	    }

	    public HttpResponseMessage Get(long id)
	    {
		    try
		    {
				string username = RequestContext.Principal.Identity.Name;
				JsonPostResponse jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPost(id), username);
				HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResponse);


				return httpResponseMessage; 
		    }
			catch (ReadException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotFound));
			}
			catch (SaveException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable));
			}

		    
        }

        [Route("post/page/{page:int}")]
		public HttpResponseMessage GetAllPostByPage(int page, string gender = "")
        {
	        try
	        {
				string username = RequestContext.Principal.Identity.Name;
				if (gender == "")
				{
					List<JsonPostResponse> jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPostAtPage(page), username);
					HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResponse);

					return httpResponseMessage;
				}

				else
				{
					List<JsonPostResponse> jsonResponse = _responseRequestPostMapper.Convert(_postService.GetPostAtPage(page, Utils.Sex(gender)), username);
					HttpResponseMessage httpResponseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResponse);

					return httpResponseMessage;
				} 
	        }
			catch (ReadException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotFound));
			}
			catch (SaveException exception)
			{
				throw new HttpResponseException(Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable));
			}
            
            
        }


    }
}