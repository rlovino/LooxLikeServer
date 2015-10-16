using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI.Repository
{
    public interface IUserRepository
    {
        User Read(long id);
        long Save(User user);
    }
}
