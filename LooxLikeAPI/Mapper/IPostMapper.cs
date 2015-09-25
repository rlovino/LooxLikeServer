using LooxLikeAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Modle;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
        PostResponse convert(DbPost post);
     //   public Post convert(PostRequest postRequest); TO DO


    }
}