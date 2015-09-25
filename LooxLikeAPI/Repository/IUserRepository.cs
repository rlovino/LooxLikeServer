using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.DBModel;

namespace LooxLikeAPI.Repository
{
    public interface IUserRepository
    {
        DbUser read(long id);
        long save(DbUser post);
    }
}
