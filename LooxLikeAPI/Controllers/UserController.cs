﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LooxLikeAPI.Services;
using LooxLikeAPI.App_Start;

namespace LooxLikeAPI.Controllers
{
    public class UserController : ApiController
    {
	    private readonly IUserService _userService;

	    public UserController(IUserService userService)
	    {
		    _userService = userService;
	    }


		[Route("user/avatar/{username}")]
        public HttpResponseMessage Get(string username)
        {
            var user = _userService.GetUser(username);
			var response = Request.CreateResponse(System.Net.HttpStatusCode.Redirect);
			response.Headers.Location = new Uri(user.PictureUrl);
			return response;
        }

        [Authorize]
        [IdentityBasicAuthentication]
        [Route("user/{id}")]
        public HttpResponseMessage Get( long id)
        {
           // var user = _userService.GetUser(id);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK,"Hello User");
            return response;
        }


    }
}
