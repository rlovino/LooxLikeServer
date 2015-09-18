using LooxLikeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LooxLikeAPI.Repository
{
    public interface IPostRepository
    {
        Post read(long id);
        long save(Post post);
    }
}
