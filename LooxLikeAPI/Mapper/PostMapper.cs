using System;
using LooxLikeAPI.Models.DBModel;

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