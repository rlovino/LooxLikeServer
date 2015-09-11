using LooxLikeAPI.Models;
using LooxLikeAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {

        public Response.PostResponse convert(Post post)
        {
            PostResponse response = new PostResponse();
            response.Id = post.Id;
            response.Message = post.Message;
            return response;
        }
    }
}