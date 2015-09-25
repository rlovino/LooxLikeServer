using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework.Constraints;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbUser
    {
        public long UserId { get; set; }
        public String Username { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Sex { get; set; }
        public String  Email { get; set; }
        public String City { get; set; }
        public DateTime Birthdat { get; set; }  
    }
}