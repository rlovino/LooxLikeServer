using LooxLikeAPI.Mapper;
using LooxLikeAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Services
{
    public class PostService : IPostService
    {
        /*
        private IPostMapper _postMapper;
        private IPostRepository _postRepository;


        public PostService(IPostRepository postRepository, IPostMapper postMapper)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
        }


      

        public IList<Post> GetPostAtPage(int page)
        {
            var dbPostResult = _postRepository.GetDbPostsByPage(page);
            return dbPostResult.Select(dbPost => _postMapper.convert(dbPost)).ToList();
        }

        public IList<Post> GetPostAtPage(int page, User.Sex sex)
        {
            var dbPostResult = _postRepository.GetDbPostsByPage(page);

            return dbPostResult.Select(currentDbPost => _postMapper.convert(currentDbPost)).Where(post => post.User.Gender == sex).ToList();
        }

        public Post GetPost(long id)
        {
            return _postMapper.convert(_postRepository.Read(id));
        }*/
        public IList<Post> GetPostAtPage(int page)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetPostAtPage(int page, User.Sex sex)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(long id)
        {
            throw new NotImplementedException();
        }
    }
}