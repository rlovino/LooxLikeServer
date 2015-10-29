using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LooxLikeAPI.Services;

namespace LooxLikeAPI.Controllers
{
    public class UserController : ApiController
    {
	    private IUserService _userService;

	    public UserController(IUserService userService)
	    {
		    _userService = userService;
	    }


		[Route("user/avatar/{username:string}")]
        public HttpResponseMessage Get(string username)
        {
            var user = _userService.GetUser(username);
            return Request.CreateResponse(System.Net.HttpStatusCode.Redirect, user.PictureUrl);
        }


    }
}
