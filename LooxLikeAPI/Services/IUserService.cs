using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
    public interface IUserService
    {
        User GetUser(long id);
	    User GetUser(string username);
    }
}