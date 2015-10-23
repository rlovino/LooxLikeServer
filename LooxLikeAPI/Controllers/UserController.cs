using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LooxLikeAPI.Services;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Controllers
{
    public class UserController : ApiController
    {
		private readonly IUserService _userService;

		public UserController(IUserService userService)
        {
			_userService = userService;
        }

        public User Get(long id)
        {
            return _userService.GetUser(id);

        }

    }
}
