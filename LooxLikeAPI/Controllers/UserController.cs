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


		[Route("user/{username:string}")]
        public HttpResponseMessage Get(string username)
        {
            var user = _userService.GetUser(username);
			HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Redirect);
				
        }


    }
}
