﻿using LooxLikeAPI.Models;
using LooxLikeAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Mapper
{
    public interface IPostMapper
    {
        PostResponse convert(Post post);
     //   public Post convert(PostRequest postRequest); TO DO


    }
}