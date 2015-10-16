using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbLike
    {
        public long PostId {get; set; }
        public long UserId { get; set; }
		public DateTime Timestamp { get; set; }
    }
}