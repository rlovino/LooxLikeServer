﻿using System.Collections.Generic;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
    public interface IPostService
    {
        IList<Post> GetPostAtPage(int page);
        IList<Post> GetPostAtPage(int page, User.Sex sex);
        Post GetPost(long id);
	    Post Save(Post post);
		IList<Post> GetLikedPostByPage(int page, long userId);
    }

}
