using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using LooxLikeAPI.Models;
using Simple.Data;

namespace LooxLikeAPI.Repository
{
    public class PostRepository : IPostRepository
    {

        private dynamic _db;

        public PostRepository(dynamic db)
        {
            this._db = db;
        }

        public Post read(long id)
        {
           return (Post)_db.Post.FindById(id);
        }

        public long save(Post post)
        {
            Post a = _db.Post.Insert(Message: post.Message);
            return a.Id;
        }
    }
}