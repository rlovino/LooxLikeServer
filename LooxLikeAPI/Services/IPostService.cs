﻿using LooxLikeAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooxLikeAPI.Services
{
    public interface IPostService
    {
        PostResponse getPostResponse(long id);
    }
}
