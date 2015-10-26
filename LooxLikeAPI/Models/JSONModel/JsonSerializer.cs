using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooxLikeAPI.Models
{
    public interface JsonSerializer
    {
        string Serialize(object o);
    }
}
