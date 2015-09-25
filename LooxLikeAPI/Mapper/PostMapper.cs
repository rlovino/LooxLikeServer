using LooxLikeAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Modle;

namespace LooxLikeAPI.Mapper
{
    public class PostMapper : IPostMapper
    {

        public Response.PostResponse convert(DbPost post)
        {
          /*  PostResponse response = new PostResponse();
            response.Id = post.Id;
            response.Message = post.Message;
            return response;*/
            throw new NotImplementedException();
        }
    }
}