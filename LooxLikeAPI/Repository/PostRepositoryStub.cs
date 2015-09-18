using LooxLikeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Repository
{
    public class PostRepositoryStub : IPostRepository
    {
        IList<Post> db;

        public PostRepositoryStub()
        {
            db = new List<Post>();
            Post post = new Post();
            post.Id = 0;
            post.Message = "messaggio"+ post.Id;
            db.Add(post);

            post = new Post();
            post.Id = 1;
            post.Message = "messaggio"+ post.Id;
            db.Add(post);
        }

        public Post read(long id)
        {

            foreach(Post p in db) 
            {
                if(p.Id.Equals(id))
                    return p;
            }
            return null;
        }

        public long save(Post post)
        {
            throw new NotImplementedException();
        }
    }

    
}