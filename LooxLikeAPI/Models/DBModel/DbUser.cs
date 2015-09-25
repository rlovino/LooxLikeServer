using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework.Constraints;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string  Email { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureUrl { get; set; }
    }
}